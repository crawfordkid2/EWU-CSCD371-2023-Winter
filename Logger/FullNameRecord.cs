using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger //all of these will be immutible records. This is because when we create a new object, we need to create a new object every time
                // Instead if we made these mutable objects, there is a chance we would overwrite something and "delete" a previous record.

{

    //here is the FullName struct, makes sure each full name has a first and last, middle can be null because not all 
    //people may have a middle name
    //struct allows for more freedom when using this for all of our other records\
    // this is an implicit way of letting the compiler know that each full name always has a first and last name while allowing middle name to be null

    public readonly record struct FullName(string First, string Last, string? Middle = null)
    {
        public string First { get; } = First ?? throw new ArgumentNullException(nameof(First));
        public string Last { get; } = Last ?? throw new ArgumentNullException(nameof(Last));
        public string Middle { get; } = Middle!;
        
       

    }

    //for all below here, we implicitly are casting name as a trait of one of these classes. 
    // For some we are using our abstract class to a property while others we are using a helper method and implicitly casting name to be first last middle
    




    //here is the book record. This implements our Abstract entity class to get a name and set it to the title
    public record Book(string Title, FullName Author, string ISBN) : AbstractEntity
    {
        public override string Name { get => Title; }

    }


    //this is the record that turns someones full name into a name, (First last middle) = name using our abstract class
    public record Someone(FullName Full): AbstractEntity
    {
        public override string Name { get => Full.ToString(); }
    }
    //the employee record uses fullname and the someone record to assign a full name and make them someone implicitly
    public record Employee(FullName Full, string Position, string Company) : Someone(Full);
    //the student record is very similar to the employee but is slightly different with what fields are needed.
    public record Student(FullName Full, string Degree, string School) : Someone(Full);
   


}
