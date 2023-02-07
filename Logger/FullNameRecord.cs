using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{

    //here is the FullName struct, makes sure each full name has a first and last, middle can be null because not all 
    //people may have a middle name
    //struct allows for more freedom when using this for all of our other records
    public readonly record struct FullName(string First, string Last, string? Middle = null)
    {
        public string First { get; } = First ?? throw new ArgumentNullException(nameof(First));
        public string Last { get; } = Last ?? throw new ArgumentNullException(nameof(Last));
        public string Middle { get; } = Middle!;
        
       

    }
    //here is the book record. This implements our Abstract entity class to get a name and set it to the title
    public record Book(string Title, FullName Author, string ISBN) : AbstractEntity
    {
        public override string Name { get => Title; }

    }


    //this is the record that turns someones full name into a name, (First middle last) = name using our abstract class
    //this is explicitly calling the name override to set the fullname while implicitly telling 
    //the console 
    public record Someone(FullName Full): AbstractEntity
    {
        public override string Name { get => Full.ToString(); }
    }
    //the employee record uses fullname and the someone record to assign a full name and make them someone implicitly
    public record Employee(FullName Full, string Position, string Company) : Someone(Full);
    //the student record is very similar to the employee but is slightly different with what fields are needed.
    public record Student(FullName Full, string Degree, string School) : Someone(Full);
   


}
