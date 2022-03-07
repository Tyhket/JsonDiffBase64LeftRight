# JsonDiffBase64LeftRight


WebApi program that has 2 http endpoints that allow you to put in Base64 encoded text and then compares the two on left and right side,
by using another http endpoint. The program uses .Net 6

Input:

PUT: v1/Controller/{id}/Left

PUT: v1/Controller/{id}/Right

DELETE: v1/Controller/{id}


Output:

GET: v1/controller/{id}

You may also delete the two or one input at a given id if you wish to do so.
Input accepts Base64 encoded text and will give an Error in the case of invalid Base64 input or whitespace.

Output Gets the two base64 encoded strings and decodes them into strings where it compares the Offset and Length of the decoded string.

Improvements:

-Include Unit and Integration Tests

-Make an external database like MSSQL

-"Use of minimal Api in .net6"
