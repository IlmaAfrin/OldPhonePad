# OldPhonePad

A C# implementation of the classic old mobile phone keypad decoding challenge.

This solution was developed as part of the Iron Software Software Sales Engineer coding challenge. Alongside the reusable decoding library, the repository includes a lightweight ASP.NET Core REST API demo and automated unit tests to demonstrate how the library can be integrated into a real application.

The focus of this project was not only to solve the problem correctly, but also to present the solution in a way that is easy to understand, maintain, test, and demonstrate to customers.

---

# Project Overview

Before smartphones became common, text messages were entered using a numeric keypad where each key represented multiple letters.

For example:

| Key Presses | Character |
|-------------|-----------|
| `2` | A |
| `22` | B |
| `222` | C |

If two consecutive letters use the same key, a space (` `) is used to separate them.

Examples:

| Input | Output |
|-------|--------|
| `33#` | `E` |
| `227*#` | `B` |
| `4433555 555666#` | `HELLO` |

The decoder also supports:

- Multiple key presses
- Pause handling (` `)
- Backspace (`*`)
- Send key (`#`)
- Input validation

---

# Solution Structure

The solution is organised into three independent projects.

```
OldPhonePad
│
├── OldPhonePad.Core
│   Reusable decoding library
│
├── OldPhonePad.Api
│   ASP.NET Core REST API demo
│
└── OldPhonePad.Tests
    Automated unit tests
```

Each project has a single responsibility.

### OldPhonePad.Core

Contains the complete decoding implementation.

The library is independent of any user interface or web framework, making it easy to reuse from console applications, desktop applications, web APIs, or other .NET projects.

### OldPhonePad.Api

A lightweight ASP.NET Core Minimal API that demonstrates one possible integration of the decoding library.

The project also includes a small homepage with example requests so customers can immediately try the API from their browser.

### OldPhonePad.Tests

Contains automated xUnit tests covering both expected behaviour and invalid input scenarios.

---

# Design Decisions

The implementation was intentionally kept simple and modular.

Some design decisions include:

- Separating the decoding logic from the REST API.
- Keeping each project focused on a single responsibility.
- Using small methods that are easy to understand and maintain.
- Reducing duplicated logic through refactoring.
- Adding automated tests before considering the implementation complete.

The objective was to create a solution that another developer could quickly understand and confidently extend.

---

# Running the Project

## Requirements

- .NET 10 SDK

Clone the repository:

```bash
git clone https://github.com/IlmaAfrin/OldPhonePad.git
```

Build the solution:

```bash
dotnet build
```

---

# Running the Unit Tests

Execute all tests with:

```bash
dotnet test
```

All tests should pass successfully.

---

# Running the REST API Demo

Start the API:

```bash
dotnet run --project OldPhonePad.Api
```

Open the URL displayed in the console (for example):

```
https://localhost:7291
```

The demo homepage includes:

- API overview
- Available endpoint
- Interactive example requests
- Expected responses
- Link back to this repository

---

# Example API Requests

### Decode a single character

```
GET /decode?input=33%23
```

Response

```json
{
  "result": "E"
}
```

---

### Decode HELLO

```
GET /decode?input=4433555%20555666%23
```

Response

```json
{
  "result": "HELLO"
}
```

---

### Invalid request

```
GET /decode?input=33
```

Response

```json
{
  "error": "Input must end with '#'."
}
```

---

# Testing

The project includes automated unit tests covering:

- Standard decoding
- Consecutive key presses
- Pause handling
- Backspace behaviour
- Missing terminating `#`
- Invalid characters
- Null input

The tests provide confidence that future refactoring does not change the expected behaviour.

---

# Additional Documentation

The repository also contains additional documentation:

| Document | Description |
|----------|-------------|
| `CUSTOMER_GUIDE.md` | Quick start guide for integrating the REST API demo. |
| `AI_USAGE.md` | Summary of how AI was used during development, as requested in the coding challenge. |

---

# Future Improvements

If this project were developed beyond the scope of the coding challenge, possible enhancements could include:

- Publishing the library as a NuGet package
- Swagger / OpenAPI documentation
- Integration tests for the REST API
- Continuous Integration with GitHub Actions
- Additional performance benchmarks

These improvements were intentionally left outside the scope of the challenge to keep the implementation focused on the requested requirements.

---

# Repository

GitHub Repository

https://github.com/IlmaAfrin/OldPhonePad

---

# Thank You

Thank you for taking the time to review this project.

I enjoyed working through the challenge and hope the solution demonstrates not only the implementation itself, but also how the library can be presented to developers and customers through clear documentation, automated testing, and a simple REST API demonstration.