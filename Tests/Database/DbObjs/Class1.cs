using Database.DbObjects;

namespace Tests.Database.DbObjs;

public class Class1 : IPersistable
{
    private Association<Class2> _assoc_class2;

}