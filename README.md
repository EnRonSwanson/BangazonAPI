# Bangazon Platform API - team EnRonSwanson

## Steps to install the code
 - Create environment variable in your .zschrc or .bashrc file. Example: `export BANGAZON_DB="/Users/mitchellblom/workspace/c19/bangazon/BangazonAPI/bang.db"`
 - Clone from github using `git clone git@github.com:EnRonSwanson/BangazonAPI.git`
 - cd into the created directory
 - In terminal execute `dotnet ef migrations add Initial`
 - Execute `dotnet ef database update`
 - Execute `dotnet run`

## How to install any dependencies
 - If you would like to interact with the database via the command line, run `npm install json`

## System configuration needed
 - Install your OS's version of DB Browser for SQLite from http://sqlitebrowser.org/

## Contributors
- Madeline Power - https://github.com/madelineepower
- Adam Reidelbach - https://github.com/adamreidelbach
- Ryan McCarty - https://github.com/therealrmac
- Mitchell Blom - https://github.com/mitchellblom