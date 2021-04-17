namespace Application.Interfaces
{
//because our application project does not have a dependency on the infrastructure project, 
// we're going to be able to access this class via an interface
    public interface IUserAccessor
    {
        string GetUsername();
    }
}