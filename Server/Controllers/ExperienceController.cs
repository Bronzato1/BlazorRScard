using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorRScard.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorRScard.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ExperienceController : ControllerBase
    {
        private static readonly Experience[] Experiences = new[] 
        {
            new Experience { 
                Id = 1, 
                Year = 1996,
                Company = "Schenk",
                Sector = Sector.FoodBeverage,
                Description = "Implementation a program of stock management with statistics and reports for the Schenk Company.",
                Keywords = new [] { "VBA", "MS ACCESS" }
            },
            new Experience {
                Id = 2,
                Year = 1996,
                Company = "Crédit Général",
                Sector = Sector.Banking,
                Description = "Prospection tool designed for the Crédit Général.",
                Keywords = new [] { "VBA", "MS ACCESS" }
            },
            new Experience {
                Id = 3,
                Year = 1997,
                Company = "Labima",
                Sector = Sector.Pharmaceutical,
                Description = "Analysis and development of client/server application for monitoring commercial delegates’ performance. Bi-directional synchronization between server and client via an internet connection.",
                Keywords = new [] { "VB SCRIPT", "MS ACCESS" }
            },
            new Experience {
                Id = 4,
                Year = 1998,
                Company = "Coca-Cola",
                Sector = Sector.FoodBeverage,
                Description = "Migration Excel macros to interrogate a server mainframe-based (SQL queries dynamically generated).",
                Keywords = new [] { "VB SCRIPT", "MAINFRAME DB2" }
            },
            new Experience {
                Id = 5,
                Year = 1998,
                Company = "Kraft Jacobs Suchard (KJS)",
                Sector = Sector.Pharmaceutical,
                Description = "Design of electronic forms dispatched via Outlook in order to collect information as part of a European survey on sales performance. With the data collected, we finalized the calculation.",
                Keywords = new [] { "VBA" }
            },
            new Experience {
                Id = 6,
                Year = 1999,
                Company = "Jpass International",
                Sector = Sector.Technology,
                Description = "Expert software for editing Material Safety Data Sheets (MSDS). Transport documents and security documents related to chemicals.",
                Keywords = new [] { "VB6", "MS ACCESS" }
            },
            new Experience {
                Id = 7,
                Year = 1999,
                Company = "Sopres",
                Sector = Sector.Marketing,
                Description = "Marketing. Data management software.",
                Keywords = new [] { "VBA", "SQL SERVER" }
            },
            new Experience {
                Id = 8,
                Year = 1999,
                Company = "Tott Systems",
                Sector = Sector.Technology,
                Description = "Freight Transport Management. Implementation of a follow-up application for rail transport. Modeling database (multiuser). Preparation of documentation and interface.",
                Keywords = new [] { "VB6", "MS ACCESS" }
            },
            new Experience {
                Id = 9,
                Year = 1999,
                Company = "Tott Systems",
                Sector = Sector.Technology,
                Description = "Designed a Helpdesk application for monitoring interventions among company’s clients. Automatic send/receive tickets. Multi site / multi company installation regardless of geographical location. Care incidents, problems, configurations, versions, etc...",
                Keywords = new [] { "VB6", "CRYSTAL REPORTS", "MS ACCESS" }
            },
            new Experience {
                Id = 10,
                Year = 1999,
                Company = "TPlan",
                Sector = Sector.Technology,
                Description = "GIS software. Designed a geospatial application GIS (Geographic Information System) to establish routes for placement of optic fibers in the ground. The software integrate Autocad maps (dwg) for mapping. Modulation and structuration of spatial data. Complete toolbox (plot, lines, curves, shapes, adding annotations, etc...).",
                Keywords = new [] { "VB6", "SQL SERVER" }
            },
            new Experience {
                Id = 11,
                Year = 2000,
                Company = "Fortis Insurance Belgium",
                Sector = Sector.Banking,
                Description = "Monitoring software for financial operations.",
                Keywords = new [] { "VB6", "MAINFRAME DB2" }
            },
            new Experience {
                Id = 12,
                Year = 2000,
                Company = "Tott Systems",
                Sector = Sector.Technology,
                Description = "Development related to year 2000 as well as the changeover to the euro currency.",
                Keywords = new [] { "VB6" }
            },
            new Experience {
                Id = 13,
                Year = 2000,
                Company = "Tott Systems",
                Sector = Sector.Technology,
                Description = "Backup solution remotely controlled through a phone connection (RDC).",
                Keywords = new [] { "VB6" }
            },
            new Experience {
                Id = 14,
                Year = 2001,
                Company = "Fortis Insurance Belgium",
                Sector = Sector.Banking,
                Description = "Development of authentication modules to access to internet services.",
                Keywords = new [] { "VB6", "MAINFRAME DB2" }
            },
            new Experience {
                Id = 15,
                Year = 2001,
                Company = "Tott Systems",
                Sector = Sector.Technology,
                Description = "Generating documentation from source code (Word and Pdf format).",
                Keywords = new [] { "VB6" }
            },
            new Experience {
                Id = 16,
                Year = 2002,
                Company = "Fortis Insurance Belgium",
                Sector = Sector.Banking,
                Description = "E-banking access securization project with Digipass reader.",
                Keywords = new [] { "VB6", "MAINFRAME DB2" }
            },
            new Experience {
                Id = 17,
                Year = 2003,
                Company = "Fortis Insurance Belgium",
                Sector = Sector.Banking,
                Description = "Back office solution for management of tax records.",
                Keywords = new [] { "VB6", "MAINFRAME DB2" }
            },
            new Experience {
                Id = 18,
                Year = 2004,
                Company = "Fortis Insurance Belgium",
                Sector = Sector.Banking,
                Description = "Internet solution for expenses validation.",
                Keywords = new [] { "VB6", "MAINFRAME DB2" }
            },
            new Experience {
                Id = 19,
                Year = 2005,
                Company = "Fortis Insurance Belgium",
                Sector = Sector.Banking,
                Description = "Participation in the development of the website dedicated to brokers bank.",
                Keywords = new [] { "VB6", "MAINFRAME DB2" }
            },
            new Experience {
                Id = 20,
                Year = 2005,
                Company = "Anonymous",
                Sector = Sector.Industry,
                Description = "Gaffe. Enterprise Content Management software (ECM) allowing storage, retrieval and diffusion of shared information within the company. Analysis, development, integration, testing and maintenance of solution. Macros allowing integration into Microsoft Outlook for archiving emails. Automatic available updates’ installation. System securization through management identity and right access to streamlines user access to logical and physical resources (disk storage).",
                Keywords = new [] { "VB6", "SQL SERVER" }
            },
            new Experience {
                Id = 21,
                Year = 2006,
                Company = "Anonymous",
                Sector = Sector.Industry,
                Description = "Transportboek. Study, analysis and design of Transport Management System - TMS. Modular design such as billing, permissions, transportation, etc. Planning and operational monitoring on transportation tours. Full integration with other company’s softwares.",
                Keywords = new [] { "VB6", "SQL SERVER" }
            },
            new Experience {
                Id = 22,
                Year = 2008,
                Company = "Anonymous",
                Sector = Sector.Industry,
                Description = "Paris. Application designed for monitoring industrial packages, capturing, processing, retrieving and updating information about a package in order to obtain its identification and status. Mobile RFID for stock operations. GPRS communication between terminal and server. RFID tags (passive) on all packages followed by the system. Automatic generation of performance indicators of type KPI logistics.",
                Keywords = new [] { "VB6", "SQL SERVER" }
            },
            new Experience {
                Id = 23,
                Year = 2009,
                Company = "Glaxo Smith Kline (GSK)",
                Sector = Sector.Pharmaceutical,
                Description = "BioStat. Scientific data collection and analysis software. Project management independently. Periodic contact with the client and writing progress reports. Respect of the specifications on time.",
                Keywords = new [] { "VBA", "ORACLE" }
            },
            new Experience {
                Id = 24,
                Year = 2010,
                Company = "Glaxo Smith Kline (GSK)",
                Sector = Sector.Pharmaceutical,
                Description = "TrattScan. Management Training courses software. Maintenance of the solution written in C-Sharp.",
                Keywords = new [] { "C#", "ORACLE" }
            },
            new Experience {
                Id = 25,
                Year = 2010,
                Company = "Glaxo Smith Kline (GSK)",
                Sector = Sector.Pharmaceutical,
                Description = "Excel solution for scheduling orders. Tool allowing order taking of new preparations and their planning on a dynamic schedule covering a full year.",
                Keywords = new [] { "VBA", "MS EXCEL" }
            },
            new Experience {
                Id = 26,
                Year = 2010,
                Company = "Akzonobel",
                Sector = Sector.Industry,
                Description = "Production Management System. Generator and calculator of production orders. Planning, monitoring, production statistics and reporting.",
                Keywords = new [] { "VBA", "EXCEL" }
            },
            new Experience {
                Id = 27,
                Year = 2010,
                Company = "Baxter",
                Sector = Sector.Pharmaceutical,
                Description = "Environment Health Safety software (EHS). Integrated management software for environmental management, health and safety at work, industrial hygiene and chemical risk management to improve well-being at work.",
                Keywords = new [] { "VB.NET", "SQL SERVER" }
            },
            new Experience {
                Id = 28,
                Year = 2010,
                Company = "Comité Olympique Belge (CIOB)",
                Sector = Sector.Sport,
                Description = "SIMS Software - Sports Information Management System for the belgian athletes.",
                Keywords = new [] { "VBA", "MS ACCESS" }
            },
            new Experience {
                Id = 29,
                Year = 2012,
                Company = "Anonymous",
                Sector = Sector.Industry,
                Description = "Web-based shuttle transport booking.",
                Keywords = new [] { "VB6", "C#", "SQL SERVER" }
            },
            new Experience {
                Id = 30,
                Year = 2014,
                Company = "Anonymous",
                Sector = Sector.Industry,
                Description = "Web-based solution designed for monitoring industrial packages, capturing, processing, retrieving and updating information about a package in order to obtain its identification and status.",
                Keywords = new [] { "VB6", "C#", "SQL SERVER" }
            },
            new Experience {
                Id = 31,
                Year = 2015,
                Company = "Anonymous",
                Sector = Sector.Industry,
                Description = "Web portal for internal communication (intranet). Personalized and secure access to content sources. News of the company. Knowledgebase.",
                Keywords = new [] { "VB6", "C#", "SQL SERVER" }
            },
            new Experience {
                Id = 32,
                Year = 2016,
                Company = "Anonymous",
                Sector = Sector.Industry,
                Description = "Web-based Transport Management System.",
                Keywords = new [] { "C#", "AURELIA", "SQL SERVER" }
            },
            new Experience {
                Id = 33,
                Year = 2018,
                Company = "Anonymous",
                Sector = Sector.Industry,
                Description = "Web-based Enterprise Content Management solution (ECM) allowing storage, retrieval and diffusion of shared information within the company.",
                Keywords = new [] { "C#", "AURELIA", "SQL SERVER" }
            }
        };
 
        [HttpGet]
        public IEnumerable<Experience> Get(int pageIndex, int pageSize)
        {
            var experiences = Experiences.OrderByDescending(x => x.Year);
            var pagedExperiences = experiences.Skip(pageSize * pageIndex).Take(pageSize);
            return pagedExperiences;
        }
    }
}