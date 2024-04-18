import { Database } from "bun:sqlite";
import { IdentifiedObject, createTableFromObject, makeInsertQueryFromObject } from "./database_utils";
import {unlinkSync} from "node:fs";
import { getParkingDetails } from "./parking_client";

const PARKING_DATABASE_FILE = 'parkering.sqlite';
const PARKING_DATA_PATH = "parkeringer.json";
const PARKING_TABLE_NAME = "parkeringer";
const PARKING_DETAILS_TABLE_NAME = "detailjer";
unlinkSync(PARKING_DATABASE_FILE);

const database = new Database(PARKING_DATABASE_FILE);

const datasetFile = Bun.file(PARKING_DATA_PATH);

const dataset = await datasetFile.json() as IdentifiedObject[];


database.run(createTableFromObject(PARKING_TABLE_NAME, dataset[0]));

const detailsObject = await getParkingDetails(dataset[0].id);
const query = createTableFromObject(PARKING_DETAILS_TABLE_NAME, detailsObject, [{tableName: PARKING_TABLE_NAME, hostColumn: "id", foreignKeyColumn: "id"}]);
database.run(query);

dataset.forEach(async (item, index) => {
	if (index % 1000 === 0) {
		console.log(index);
	}
	const query = makeInsertQueryFromObject(PARKING_TABLE_NAME, item);
	database.run(query);

	const details = await getParkingDetails(item.id);
	database.run(makeInsertQueryFromObject(PARKING_DETAILS_TABLE_NAME, details));
});


