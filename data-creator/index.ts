import pLimit from 'p-limit';
import { getParkingDetails } from './parking_client';
import { Database } from 'bun:sqlite';
import { unlinkSync } from 'node:fs';
import {
  IdentifiedObject,
  createTableFromObject,
  makeInsertQueryFromObject,
} from './database_utils';

const PARKING_DATABASE_FILE = 'parkering.sqlite';
const PARKING_DATA_PATH = 'parkeringer.json';
const PARKING_TABLE_NAME = 'parkeringer';
const PARKING_DETAILS_TABLE_NAME = 'detailjer';

unlinkSync(PARKING_DATABASE_FILE);
const database = new Database(PARKING_DATABASE_FILE);

const datasetFile = Bun.file(PARKING_DATA_PATH);
const dataset = (await datasetFile.json()) as IdentifiedObject[];

database.run(createTableFromObject(PARKING_TABLE_NAME, dataset[0]));

const detailsObject = await getParkingDetails(dataset[0].id);
const query = createTableFromObject(
  PARKING_DETAILS_TABLE_NAME,
  detailsObject,
  [{ tableName: PARKING_TABLE_NAME, hostColumn: 'id', foreignKeyColumn: 'id' }]
);
database.run(query);

// 🌟 Begrens til maks 25 samtidige kall, ref: https://nvdb.atlas.vegvesen.no/docs/produkter/nvdbapil/v3/introduksjon/Ratelimiter/
const limit = pLimit(25);

let i = 0;

const tasks = dataset.map(item => limit(async () => {
  if (i++ % 1000 === 0) console.log(`Processed ${i}`);

  database.run(makeInsertQueryFromObject(PARKING_TABLE_NAME, item));

  try {
    const details = await getParkingDetails(item.id);
    database.run(makeInsertQueryFromObject(PARKING_DETAILS_TABLE_NAME, details));
  } catch (error) {
    console.error(`Failed to get details for ID ${item.id}:`, error);
  }
}));

await Promise.all(tasks);
