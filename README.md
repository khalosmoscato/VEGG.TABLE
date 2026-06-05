# Welcome to VEGG.TABLE
VEGG.TABLE is a peer-to-peer marketplace for community grown foodstuffs. 
To promote sustainable microproduce and community food resilience. We provide a platform for local producers to sell the crops, garden plants and foodstuffs that they grow in the community to the community around them.

Our whiteboard: [Figma Board](https://www.figma.com/board/jRS3cdT5qpY0piIOLnXisa/VEGG.TABLE?node-id=0-1&p=f&t=Jq6VlaDEQLm4XsCp-0) \
Our Architecture : [Architecture](./Architecture.md)
---

## Running the Project

During the development phase we are using Docker containeristaion to run our Web-application on a range of machines. We are using an MSSQL server which should run locally on your machine.

Please follow these steps in order to ensure all services are correctly initialized:
1. Open DockerDesktop
2. After cloning the repo open the project in visual studio 2026. 



0. **Setup**: Open 4 terminals and ensure Docker Desktop is running.
1. **Terminal 1 (Database)**: Open your terminal at the root and run `docker-compose up -d`. This starts the SQL Server container, ensuring the database is active (Docker Desktop must be running).
2. **Terminal 2 (API)**: Navigate to `src/VEGG.TABLE.API/` and run `dotnet run`. This hosts your data service on port 5167.
3. **Terminal 3 (Tailwind)**: Navigate to `src/VEGG.TABLE.Client/` and run `npm run dev`. This monitors your CSS and recompiles Tailwind styles in real-time.
4. **Terminal 4 (Blazor Frontend)**: In the same `Client` directory, run `dotnet watch`. This hosts the Blazor application, enabling live-reloading as you modify your code.

## Dependencies

We are using NET10.0 architecture using the most up to date dependencies available in 2026.

The running the project instructions will not function on a Windows machine using ARM rather than AMD architecture.

### Our Team of VEGG.TABLE creators

* [Khalos M](https://github.com/khalosmoscato)
* [Jinlue "Leo" Z](https://github.com/Leoreoreoreo)
* [Vladimir S](https://github.com/VladStam)
* [Leao B](https://github.com/lleaob)
* [Chloe R-B](https://github.com/chloerb97)


