# Currency Exchange Rate Checker

## Overview
Currency Exchange Rate Checker is a simple C# console application that allows users to quickly fetch the latest exchange rates for various currencies. The application provides real-time currency conversion rates using a free exchange rate API.

## Features
- Fetch real-time exchange rates
- Support for multiple base currencies
- Simple, interactive console interface
- Error handling for network and API issues
- Easy to use and extend

## Prerequisites
- .NET SDK 6.0 or later
- Visual Studio Code (recommended)
- Internet connection

## Installation

### 1. Clone the Repository
```bash
git clone https://github.com/mohsadiq/CurrencyExchangeRateChecker.git
cd CurrencyExchangeRateChecker
```

### 2. Restore Dependencies
```bash
dotnet restore
```

### 3. Build the Project
```bash
dotnet build
```

## Running the Application
```bash
dotnet run
```

## How to Use
1. Run the application
2. Enter a 3-letter currency code (e.g., USD, EUR, GBP)
3. View exchange rates for multiple currencies
4. Type 'exit' to quit the application

### Example Usage
```
Currency Exchange Rate Checker

Enter the base currency code (e.g., USD, EUR, GBP) or 'exit' to quit: USD

Exchange Rates for USD:
1 USD = 0.9234 EUR
1 USD = 0.7654 GBP
1 USD = 110.23 JPY
...

Enter the base currency code (e.g., USD, EUR, GBP) or 'exit' to quit: exit
```

## API Used
- Exchange Rate API (https://www.exchangerate-api.com/)
- Free tier with no authentication required

## Dependencies
- System.Net.Http
- Newtonsoft.Json

## Potential Improvements
- Add more comprehensive currency information
- Implement local caching of exchange rates
- Create a more advanced user interface
- Add support for historical exchange rate data


## License
Distributed under the MIT License. See `LICENSE` for more information.
