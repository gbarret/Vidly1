using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly1.Models
{
    public class MembershipType
    {
        public byte Id { get; set; }
        public string Name { get; set; }
        public short SignUpFee { get; set; }
        public byte DurationInMonths { get; set; }
        public byte DiscountRate { get; set; }

        // 20190331 Replacing Magic numbers used by the Min18YearIfAMember custom validation ...
        // 20190331 Definig some static fields as part of the ReFactoring. Giving "names" to the MembershipTypes ...
        public static readonly byte Unknown = 0;    // Matching the DB Values ...
        public static readonly byte PayAsYouGo = 1; // Matching the DB Values ...
        // Later, if needed we can define other values. For now, we do not need to define all the values such as 2, 3, .....
    }
}