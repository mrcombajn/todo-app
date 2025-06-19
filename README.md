# Todo List

## Table of Contents

* [General Info](#general-information)
* [Features](#features--roadmap)
* [Get Started](#get-started)
* [Contact](#contact)


## General Information

The task is to write an application entitled. ‘Todo List’


## Features / Roadmap

### Functionality
- [x] CRUD operations on 'Todos'
- [x] Changing day of displayed 'Todos'
- [x] Notifications about upcoming tasks


#### Environment:
- [x] Add readme
- [x] Automate build process:
    - [x] Build on PR push
    - [x] Automatic releases of backend to VPS
    - [x] Automatic releases of frontend to FTP	


#### Plans for the future: 
- [ ] Add users to database, so each one will have own board


### Running an application:

Running the project locally requires Docker to be installed:
In the path /TodoApi/TodoApi type the command:
```cmd
 docker compose up -d --build --force-recreate --no-deps
```
It's possible that in the case of local build you will have to type this command twice, sometimes the api could not connect to the database and only started working after a restart

in the path /todo-app-front run the commands:
```cmd
npm install
npm run build
```

## Contact

Created by [Mateusz Ostrowski (@mrcombajn)](https://github.com/mrcombajn) - feel free to contact me!