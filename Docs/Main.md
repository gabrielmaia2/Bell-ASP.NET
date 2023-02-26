# Main

## Business rules

All products should return 20% of the sale price to the company.

The data should be stored in a MySql database.

## Data specifications

When creating new tables based on models, the names of the columns should always follow the names of the properties in snake_case (e.g. DataProperty property would correspond to the column data_property).

Primary keys should have their names specified as PK_(type_name).

### Product

- Id: Is the primary key, unsigned 64-bit integer, should be auto-generated and always be unique;
- Name: Is a text ranging from 6 to 200 characters, should accept all unicode characters and be required;
- Description: Is a text ranging from 0 to 5000 characters and should accept all unicode characters;
- Price: Is a real number with 8 non-decimal and 2 decimal digits, should be non-negative;

Usages:

1. [Add Product](Seller/Add%20Product.md).
