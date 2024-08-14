
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
    string sql = @"
    SELECT houses.*, accounts.* 
    FROM houses
    JOIN accounts ON accounts.id = houses.creatorId;";

    List<House> houses = _db.Query<House, Profile, House>(sql, (house, account) =>
    {
      house.Creator = account;
      return house;
    }).ToList();

    return houses;
  }

  public House GetHouseById(int houseId)
  {
    string sql = @"
    SELECT houses.*, accounts.* 
    FROM houses 
    JOIN accounts ON accounts.id = houses.creatorId 
    WHERE houses.id = @houseId;";

    House house = _db.Query<House, Profile, House>(sql, (house, account) =>
    {
      house.Creator = account;
      return house;
    }, new { houseId }).FirstOrDefault();
    return house;
  }

  public House CreateHouse(House houseData)
  {
    string sql = @"
    INSERT INTO
    houses (bedrooms, bathrooms, levels, imgUrl, year, price, description, creatorId)
    VALUES
    (@Bedrooms, @Bathrooms, @Levels, @ImgUrl, @Year, @Price, @Description, @CreatorId);

    SELECT
    houses.*, accounts.*
    FROM houses
    JOIN accounts ON accounts.id = houses.creatorId
    WHERE houses.id = LAST_INSERT_ID();";

    House house = _db.Query<House, Profile, House>(sql, (house, account) =>
    {
      house.Creator = account;
      return house;
    }, houseData).FirstOrDefault();

    return house;
  }

  internal void DestroyHouse(int houseId)
  {
    string sql = @"DELETE FROM houses WHERE id = @houseId LIMIT 1;";
  }
}