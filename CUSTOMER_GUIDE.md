# Customer Guide

## Introduction

Thank you for trying the OldPhonePad REST API demo.

This guide shows how to use the API to decode messages entered using the classic mobile phone keypad. The API is intentionally simple so that developers can quickly understand how the decoding library can be integrated into their own applications.

---

# Starting the Demo

Run the API project:

```bash
dotnet run --project OldPhonePad.Api
```

Once the application starts, open the URL displayed in the console.

For example:

```
https://localhost:7291
```

The homepage provides:

- A brief introduction
- The available API endpoint
- Clickable example requests
- Expected responses

No additional configuration is required.

---

# API Endpoint

```
GET /decode?input=<encoded_message>
```

The `input` parameter contains the encoded keypad message.

Because `#` has a special meaning in URLs, it must be URL encoded as `%23`.

---

# Example Requests

## Decode a single character

Request

```
/decode?input=33%23
```

Response

```json
{
  "result": "E"
}
```

---

## Decode a complete word

Request

```
/decode?input=4433555%20555666%23
```

Response

```json
{
  "result": "HELLO"
}
```

---

## Backspace example

Request

```
/decode?input=227*%23
```

Response

```json
{
  "result": "B"
}
```

---

# Error Handling

If the input is invalid, the API returns a **400 Bad Request** response with a descriptive error message.

Example:

Request

```
/decode?input=33
```

Response

```json
{
    "error": "Input must end with '#'."
}
```

---

# Integration Example

Any application capable of making HTTP requests can call the API.

For example:

```
GET https://localhost:7291/decode?input=33%23
```

The response is standard JSON and can easily be consumed by desktop applications, web applications, mobile applications, or other backend services.

---

# Additional Information

This REST API is provided as a demonstration of how the `OldPhonePad` decoding library can be exposed through a web service.

The decoding logic itself remains completely independent from the web layer, making it reusable in any .NET application.

For implementation details, unit tests, and source code, please refer to the project README.