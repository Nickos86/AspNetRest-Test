


*a short description of your API what have used:*
- TransactionsController encapsulates the API and endpoints. I used WebAPI 2 and tried to keep as close to rest constraints and http standards
- storage uses a singleton class of ITransactionRepository.

*debugging instructions (don't forget point 1) any comments you wish to add:*
- for "get a list" - navigate to http://localhost:<port>/api/transactions
- for "get a transaction" - using any one of the above transactionId's, navigate to http://localhost:<port>/api/transactions/<transactionId>
- for create a new transaction, update or delete transaction use a tool such as curl or fiddler with standard http verbs. example:
http://localhost:<port>/api/transactions/<transactionId> -X POST -d "transactionId=7&Description=test"

*The time you spent on the project:*
2hr 20min.

*If you ran out of time, but would have liked to implemented certain features, tell us why*

I ran out of time so update, delete and save have basic unit tests and no UI for ease of use (although this isnt in the spec).

I also missed the spec case "Merchant and Description are optional" as my model is just a simple POCO. This would have taken 10 seconds to protect against invariants via the constructor.

I also would have created Dtos for endpoint request and reponses.
