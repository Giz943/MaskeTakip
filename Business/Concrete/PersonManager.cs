using System;
using System.Collections.Generic;
using Business.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class PersonManager : IApplicantService
    {
        public void ApplyForMask(Person person)
        {
            
        }

        public List<Person> GetList()
        {
            return null;
        }

        public bool CheckPerson(Person person)
        {
            //mernis kontrolü yapılacak.
            KPSPublicSoapClient client = new KPSPublicSoapClient(KPSPublicSoapClient.
            EndpointConfiguration.KPSPublicSoap);
            return client.TCKimlikNoDogrulaAsync(
            new TCKimlikNoDogrulaRequest
            (new TCKimlikNoDogrulaRequestBody
            (person.NationalIdentity, Ad: person.FirstName,Soyad: person.LastName,person.DateOfBirthYear)))
            .Result.Body.TCKimlikNoDogrulaResult;


        }
    }
}
