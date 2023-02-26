# Publish product

## Preconditions

- The seller should be logged in to publish new products;

## API and end-user app

- The fields to send in the query should be name, description and price, with constraints described in the [data specifications](../Main.md);
  - The id will be auto-generated, as described in the data specifications;
- There will be also a fourth optional field, checkForDuplicates, boolean, which should be true by default;
  - If checkForDuplicates is not set or if it is true, if there already exists another product with same name published by the seller, then the product should not be published, displaying an error;
  - If checkForDuplicates is false, then the seller should be able to publish the product even if there already exists another product with same name;
- Every product must be associated with a profile;
  - All products should be associated only with the profile of the seller currently logged in;
- The added product should always be returned after published.

## End-user app only

- The seller should be able to cancel the operation before he publishes the product;
  - When that happens, it should get back to view his profile;
- For the name and description fields, there should be counters showing the number of characters left;
  - The counter starts at its maximum value for a field and decreases as each new character is typed at that field;
  - When there are no characters left and the seller adds more characters, the counter should become red and negative, showing how many characters were written past the limit;
