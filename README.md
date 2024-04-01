# DafWarden
This is a .Net CLI tool to generate passphrase following the *Diceware* method ( you can learn more about it  [here](http://world.std.com/~reinhold/diceware.html)).
Here is how to use it.

## Overview

The passphrase generator is composed of several components:

- `PassphraseFragmentRepository`: A class responsible for retrieving passphrase fragments from a data source.
- `PassphraseGenerator`: A class that generates passphrases using the passphrase fragments obtained from the repository.
- `Executor`: An application class that interacts with the user to generate passphrases.

## Usage

To use the passphrase generator, follow these steps:

1. Ensure you have the required dependencies installed.
2. Build and run the project.
3. Enter the desired passphrase length when prompted.
4. The generator will produce a passphrase based on the specified length and display it to the user.
5. Optionally, you can choose to continue generating passphrases.

## Components

### PassphraseFragmentRepository

This class loads passphrase fragments from a CSV file named `diceware.csv` located in the same directory as the executable.

### PassphraseGenerator

The `PassphraseGenerator` class generates passphrases by randomly selecting passphrase fragments from the repository. It uses a specified length to determine the number of fragments to combine into the passphrase.

### Executor

The `Executor` class provides a command-line interface for users to interact with the passphrase generator. It prompts the user to enter the desired passphrase length and displays the generated passphrase.

## Dependencies

- .NET 8
- FluentResults (dependency for handling results and errors)

## Setup

1. Clone this repository.
2. Ensure you have .NET 8 installed on your system.
3. Build the project using `dotnet build`.
4. Run the application using `dotnet run`.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

