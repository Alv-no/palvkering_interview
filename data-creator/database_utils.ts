export type IdentifiedObject = {
	id: number;
	[key: string]: number | string | null;
}

export type ForeignKeyRelation = {
	tableName: string;
	foreignKeyColumn: string;
	hostColumn: string;
}

export const createTableFromObject = (tableName: string, jsonObject: IdentifiedObject, relations: ForeignKeyRelation[] = []) => {
        const columnDefinitions = Object.entries(jsonObject).map(entry => createColumnDefinition(entry[0], entry[1])).join(", "); 
	const trimmedColumnDefinitions = columnDefinitions.substring(0, columnDefinitions.length - 1);

	const foreignKeyRelations = relations.map(relation => createForeignKeySQL(relation)).join("");

	const query = `CREATE TABLE ${tableName}(${trimmedColumnDefinitions}${foreignKeyRelations})`;

	return `${query.trim()};`;
}

export const createColumnDefinition = (key: string, value: number | string | null) => {
	if (key === "id") {
		return `${key} ${mapJavascriptDataTypeToSqlite(value)} PRIMARY KEY`;
	}
	return `${key} ${mapJavascriptDataTypeToSqlite(value)}`;
}

export const makeInsertQueryFromObject = (tableName: string, jsonObject: IdentifiedObject) => {
	const columnNames = Object.entries(jsonObject).map(entry => entry[0]).join(", ");
	const values = Object.entries(jsonObject).map(entry => mapObjectValueToSqliteValue(entry[1])).join(", ");
	const query = `INSERT INTO ${tableName} (${columnNames}) VALUES (${values});`;	

	return query;
}

const mapJavascriptDataTypeToSqlite = (value: number | string | null) => {
	switch(typeof value) {
	case "string":
		return "text";
	case "number":
		return "integer";
	case "bigint":
		return "integer";
	case "boolean":
		return "integer";
	default:
		return "text";
	}
}

const createForeignKeySQL = (relation: ForeignKeyRelation) => {
	return `, FOREIGN KEY (${relation.hostColumn}) REFERENCES ${relation.tableName}(${relation.foreignKeyColumn})`;
}


const mapObjectValueToSqliteValue = (value: string | number | null) => {
	switch(typeof value) {
		case "string":
	             return `'${value.replaceAll("'", "")}'`;
		case "number":
	return `${value}`;	
		case "bigint":
	return `${value}`;	
		case "boolean":
	return `${value ? 1 : 0}`;	
        default:
		return "''";
	}
}

