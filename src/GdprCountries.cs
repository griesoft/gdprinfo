using System.Collections.Generic;

namespace GdprInfo
{
    /// <summary>
    /// A collection of countries in the European Economic Area (Eea) and subject to the GDPR regulation.
    /// </summary>
    public static class GdprCountries
    {
        private static readonly List<Country> _countries = new List<Country>()
        {
            new Country() { IsoCountryCode = "AT",  Name = "Austria", Number = "040", LongCountryCode = "AUT" },
            new Country() { IsoCountryCode = "BE",  Name = "Belgium", Number = "056", LongCountryCode = "BEL" },
            new Country() { IsoCountryCode = "BG",  Name = "Bulgaria", Number = "100", LongCountryCode = "BGR" },
            new Country() { IsoCountryCode = "HR",  Name = "Croatia", Number = "191", LongCountryCode = "HRV" },
            new Country() { IsoCountryCode = "CY",  Name = "Cyprus", Number = "196", LongCountryCode = "CYP" },
            new Country() { IsoCountryCode = "CZ",  Name = "Czechia", Number = "203", LongCountryCode = "CZE" },
            new Country() { IsoCountryCode = "DK",  Name = "Denmark", Number = "208", LongCountryCode = "DNK" },
            new Country() { IsoCountryCode = "EE",  Name = "Estonia", Number = "233", LongCountryCode = "EST" },
            new Country() { IsoCountryCode = "FI",  Name = "Finland", Number = "246", LongCountryCode = "FIN" },
            new Country() { IsoCountryCode = "FR",  Name = "France", Number = "250", LongCountryCode = "FRA" },
            new Country() { IsoCountryCode = "DE",  Name = "Germany", Number = "276", LongCountryCode = "DEU" },
            new Country() { IsoCountryCode = "GR",  Name = "Greece", Number = "300", LongCountryCode = "GRC" },
            new Country() { IsoCountryCode = "HU",  Name = "Hungary", Number = "348", LongCountryCode = "HUN" },
            new Country() { IsoCountryCode = "IE",  Name = "Ireland", Number = "372", LongCountryCode = "IRL" },
            new Country() { IsoCountryCode = "IT",  Name = "Italy", Number = "380", LongCountryCode = "ITA" },
            new Country() { IsoCountryCode = "LV",  Name = "Latvia", Number = "428", LongCountryCode = "LVA" },
            new Country() { IsoCountryCode = "LT",  Name = "Lithuania", Number = "440", LongCountryCode = "LTU" },
            new Country() { IsoCountryCode = "LU",  Name = "Luxembourg", Number = "442", LongCountryCode = "LUX" },
            new Country() { IsoCountryCode = "MT",  Name = "Malta", Number = "470", LongCountryCode = "MLT" },
            new Country() { IsoCountryCode = "NL",  Name = "Netherlands", Number = "528", LongCountryCode = "NLD" },
            new Country() { IsoCountryCode = "PL",  Name = "Poland", Number = "616", LongCountryCode = "POL" },
            new Country() { IsoCountryCode = "PT",  Name = "Portugal", Number = "620", LongCountryCode = "PRT" },
            new Country() { IsoCountryCode = "RO",  Name = "Romania", Number = "642", LongCountryCode = "ROU" },
            new Country() { IsoCountryCode = "SK",  Name = "Slovakia", Number = "703", LongCountryCode = "SVK" },
            new Country() { IsoCountryCode = "SI",  Name = "Slovenia", Number = "705", LongCountryCode = "SVN" },
            new Country() { IsoCountryCode = "ES",  Name = "Spain", Number = "724", LongCountryCode = "ESP" },
            new Country() { IsoCountryCode = "SE",  Name = "Sweden", Number = "752", LongCountryCode = "SWE" },
            new Country() { IsoCountryCode = "GB",  Name = "United Kingdom", Number = "826", LongCountryCode = "GBR" }
        };

        /// <summary>
        /// Returns all countries that are in the European Economic Area and subject to the GDPR regulation.
        /// </summary>
        public static IEnumerable<Country> Countries
        {
            get
            {
                foreach (var country in _countries)
                {
                    yield return country;
                }
            }
        }

        /// <summary>
        /// Returns only the ISO country codes from the EEA country list.
        /// </summary>
        public static IEnumerable<string> IsoCountryCodes
        {
            get
            {
                foreach (var country in _countries)
                {
                    yield return country.IsoCountryCode;
                }
            }
        }

        /// <summary>
        /// Returns only the country names from the EEA country list.
        /// </summary>
        public static IEnumerable<string> CountryNames
        {
            get
            {
                foreach (var country in _countries)
                {
                    yield return country.Name;
                }
            }
        }

        /// <summary>
        /// Returns only the country numbers from the EEA country list.
        /// </summary>
        public static IEnumerable<string> CountryNumbers
        {
            get
            {
                foreach (var country in _countries)
                {
                    yield return country.Number;
                }
            }
        }

        /// <summary>
        /// Returns only the long country codes from the EEA country list.
        /// </summary>
        public static IEnumerable<string> LongCountryCodes
        {
            get
            {
                foreach (var country in _countries)
                {
                    yield return country.LongCountryCode;
                }
            }
        }
    }

    /// <summary>
    /// Model that contains country name, iso code, number and long alphabetic code.
    /// </summary>
    public class Country
    {
        public string Name { get; set; } = "";

        public string Number { get; set; } = "";

        public string IsoCountryCode { get; set; } = "";

        public string LongCountryCode { get; set; } = "";
    }
}
