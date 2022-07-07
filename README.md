# Contact List API

API which stores people and their contacts. A person can have multiple contacts such as `Phone`, `Email` or `Whatsapp`.


## Setting the project up

## Usage

### CLI

Clone this repository and execute:

```bash
dotnet restore
dotnet run
```

### Docker

Run the existing image by executing:

```bash
docker pull viniciusvviterbo/contactlistapi:latest
docker run -d --rm -p 8080:80 viniciusvviterbo/contactlistapi:latest
```
or build your own image by cloning this repository and executing:

```bash
dotnet restore
dotnet publish -c Release

docker build -t viniciusvviterbo/contactlistapi .
docker run -d --rm -p 8080:80 viniciusvviterbo/contactlistapi
```

**[GNU AGPL v3.0](https://www.gnu.org/licenses/agpl-3.0.html)**