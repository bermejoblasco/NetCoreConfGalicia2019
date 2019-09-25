using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.AspNetCore.Mvc;
using NetCoreConf.Galicia._2019.Response.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;


namespace NetCoreConf.Galicia._2019.Response.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController: ControllerBase
    {
         private TelemetryClient telemetry;

        public PersonsController(TelemetryClient telemetry)
        {
            this.telemetry = telemetry;
        }

        [HttpGet()]
        public ActionResult<IEnumerable<Person>> GetAll()
        {
            var speakers = GetPersons();
            this.telemetry.TrackTrace($"Request all persons", SeverityLevel.Information);
            this.telemetry.TrackEvent($"RequestAllPersons");

            return speakers;
        }

        [HttpGet("error")]
        public ActionResult<string> GetError()
        {
            throw new Exception("Mi excepcion. Con mi error personalizado: Lorem ipsum");
        }

        [HttpGet("{id}")]
        public ActionResult<Person> GetSpeakers(int id)
        {
            Person one = null;
            try
            {
                one = GetPersons().Single(s => s.Id == id);
                this.telemetry.TrackTrace($"Person {id} founded", SeverityLevel.Information);
            }
            catch (Exception ex)
            {
                this.telemetry.TrackException(ex);
                throw ex;
            }
            return one;
        }
        

        [HttpGet("search/{search}")]
        public ActionResult<IEnumerable<Person>> GetSearch(string search)
        {
            var speakers = GetPersons().Where(s => s.Name.Contains(search, StringComparison.InvariantCultureIgnoreCase)).ToList();

            return speakers;
        }

        [HttpGet("ranking")]
        public ActionResult<string> RankingPersons()
        {
            var persons = this.GetPersons();
            string rankingId = Guid.NewGuid().ToString();

            foreach (var item in persons)
            {
                telemetry.TrackEvent($"RankingPersons", new Dictionary<string, string>() {
                    { "RankingId", rankingId },
                    { "Name", item.Name },
                    { "Rank", item.RankingValue.ToString() },
                    { "Type", item.Type.ToString() }
                });
            }

            telemetry.Flush();

            return rankingId;
        }

        private List<Person> GetPersons()
        {
            var i = 1;
            return new List<Person>()
            {
                new Person(i++, "Fernando Escolar")
                , new Person(i++,"J.Rafa Ramón")
                , new Person(i++,"Robert Bermejo")
                , new Person(i++,"Sergio Parra Guerra")
                , new Person(i++,"Beatriz Márquez Heredia")
                , new Person(i++,"Marcos Lora Rosa")
                , new Person(i++,"Carlos Mendible")
                , new Person(i++,"Luis Ruiz Pavón")
                , new Person(i++,"Txema Balseiro")
                , new Person(i++,"Antonio José Soto Rodriguez")
                , new Person(i++,"Antonio Marin Alberdi")
                , new Person(i++,"Javier Torrecilla Puertas")
                , new Person(i++,"Laura Beltran")
                , new Person(i++,"Josué Yeray Julián")
                , new Person(i++,"Unai Zorrilla Castro")
                , new Person(i++,"David Gonzalo")
                , new Person(i++,"Adrian Diaz Cervera")
                , new Person(i++,"Javier Menendez Pallo")
                , new Person(i++,"Diego Zapico Ferreiro")
                , new Person(i++,"Nacho Fanjul")
                , new Person(i++,"Santiago Porras Rodríguez")
                , new Person(i++,"Anna Almuni Marcó")
                , new Person(i++,"Manuel Sánchez Rodríguez")
                , new Person(i++,"Elena Salcedo")
                , new Person(i++,"Pablo Bouzada Santomé")
                , new Person(i++,"Manuel Vilachan")
                , new Person(i++,"Alberto Rodriguez", TypePerson.Staff)
                , new Person(i++,"Pepe perez", TypePerson.Attendant)
                , new Person(i++,"Elena Nito del Bosque", TypePerson.Attendant)
                , new Person(i++,"Darth Vader", TypePerson.Attendant)
                , new Person(i++,"Chewbacca", TypePerson.Attendant)
                , new Person(i++,"Yoda", TypePerson.Attendant)
                , new Person(i++,"Luke Skywalker", TypePerson.Attendant)
                , new Person(i++,"R2-D2", TypePerson.Attendant)
                , new Person(i++,"Obi-Wan Kenobi", TypePerson.Attendant)
                , new Person(i++,"Anakin Skywalker", TypePerson.Attendant)
                , new Person(i++,"Han Solo", TypePerson.Attendant)
                , new Person(i++,"Darth Sidious", TypePerson.Attendant)
                , new Person(i++,"Snoke", TypePerson.Attendant)
                , new Person(i++,"Leia Skywalker", TypePerson.Attendant)
                , new Person(i++,"C3PO", TypePerson.Attendant)
                , new Person(i++,"Jabba el Hutt", TypePerson.Attendant)
                , new Person(i++,"Jar Jar Bink", TypePerson.Attendant)
                , new Person(i++,"Poe Dameron", TypePerson.Attendant)

            };
        }
    }
}
