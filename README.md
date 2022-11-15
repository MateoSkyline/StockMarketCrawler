<h1 align="center"> Stock Market Crawler </h1>

<div align="center"> <img alt="C#" src="https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=c-sharp&logoColor=white"/> <img alt=".NET" src="https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white"/>  <img alt="Postgres" src ="https://img.shields.io/badge/postgres-%23316192.svg?style=for-the-badge&logo=postgresql&logoColor=white"/> <img alt="Docker" src="https://img.shields.io/badge/docker-%230db7ed.svg?style=for-the-badge&logo=docker&logoColor=white"> <img alt="Visual Studio 2022" src="https://img.shields.io/badge/Visual%20Studio-5C2D91.svg?style=for-the-badge&logo=visual-studio&logoColor=white"> <img alt="Github Actions" src="https://img.shields.io/badge/github%20actions-%232671E5.svg?style=for-the-badge&logo=githubactions&logoColor=white"> </div>

![-----------------------------------------------------](https://raw.githubusercontent.com/andreasbm/readme/master/assets/lines/rainbow.png)

<!-- TABLE OF CONTENTS -->
<h2 id="table-of-contents"> :book: Table of Contents</h2>

* [About the Project](#about-the-project) 
  * [Description](#about-project) 
  * [Features list](#features-list) 
  * [Branches](#branches) 
* [Features](#features) 
* [How to install](#installation)

![-----------------------------------------------------](https://raw.githubusercontent.com/andreasbm/readme/master/assets/lines/rainbow.png)

<!-- ABOUT THE PROJECT -->
<h2 id="about-the-project"> :pencil: About The Project</h2>

<h3 id="about-project">Description</h3>

TODO

<h3 id="features-list">Features list</h3>

* [Example feature](#feat-example)

<h3 id="branches">Branches</h3>

* **main**: main, stable releases
* **feature/**: daily builds - can be unstable.

![-----------------------------------------------------](https://raw.githubusercontent.com/andreasbm/readme/master/assets/lines/rainbow.png)

<!-- FEATURES -->
<h2 id="features"> :cloud: Features</h2>

<h3 id="feat-example">Example feature</h2>

TODO

![-----------------------------------------------------](https://raw.githubusercontent.com/andreasbm/readme/master/assets/lines/rainbow.png)

<!-- STRUCTURE -->
<h2 id="about-the-project"> :nut_and_bolt: Structure</h2>

```
|-- README.md
`-- StockMarketCrawler
    |-- StockMarketCrawler.csproj
    |-- StockMarketCrawler.Exceptions.cs
    |-- Program.cs
    `-- Services
        |-- ConfigurationService.cs
        |-- DatabaseService.cs
        |-- LoggerService.cs
    `-- Models
        |-- Dividend.Model.cs
        |-- Job.Model.cs
        |-- Status.Property.cs
        |-- Ticker.Model.cs
    `-- Logic
        |-- Crawler.cs
        |-- Saver.cs
        `-- GetDividends
            |-- GetDividends.Crawler.cs
            |-- GetDividends.Saver.cs
            |-- GetDividends.cs
        `-- GetTickers
            |-- GetTickers.Crawler.cs
            |-- GetTickers.Saver.cs
            |-- GetTickers.cs
        `-- JobHandler
            |-- JobHandler.cs
    `-- Interfaces
        |-- IConfiguration.cs
        |-- ILogger.cs
    `-- Database
        |-- Database.sql
`-- StockMarketCrawler.Tests
    |-- StockMarketCrawler.Tests.csproj
    `-- Logic
        |-- GetTickers.UnitTest.cs
```

![-----------------------------------------------------](https://raw.githubusercontent.com/andreasbm/readme/master/assets/lines/rainbow.png)

<!-- HOW TO INSTALL -->
<h2 id="installation"> :hammer: How to install</h2>

TODO

