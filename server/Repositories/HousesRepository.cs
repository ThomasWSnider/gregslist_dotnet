namespace gregslist_dotnet.Repositories;

public class HousesRepository
{
  private readonly IDbConnection _db;


  public HousesRepository(IDbConnection db)
  {
    _db = db;
  }

  public List<House> GetAllHouses()
  {
    string sql = "SELECT * FROM houses;";

    List<House> houses = _db.Query<House>(sql).ToList();

    return houses;
  }
}