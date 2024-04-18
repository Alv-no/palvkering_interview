import { expect, test, describe } from "bun:test";
import { createTableFromObject } from "./database_utils";

describe("createTableFromObject", () => {
	test("simple case", () => {
		const query = createTableFromObject("simple", {
			id: 5,
			value: "test"
		});

		const expectedQuery = "CREATE TABLE simple(id integer PRIMARY KEY, value text);";

		expect(query).toBe(expectedQuery);
	});

	test("With foregin key", () => {

		const query = createTableFromObject("simple", {
			id: 5,
			value: "test"
		}, [{
			tableName: "simpleDetails",
			foreignKeyColumn: "id",
			hostColumn: "id"
		}]);

		const expectedQuery = "CREATE TABLE simple(id integer PRIMARY KEY, value text) FOREIGN KEY (id) REFERENCES simpleDetails(id);";

		expect(query).toBe(expectedQuery);
	});
})



