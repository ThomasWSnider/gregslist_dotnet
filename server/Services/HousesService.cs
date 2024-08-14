
namespace gregslist_dotnet.Services;

public class HousesService
{
  private readonly HousesRepository _housesRepository;

  public HousesService(HousesRepository housesRepository)
  {
    _housesRepository = housesRepository;
  }

  public List<House> GetAllHouses()
  {
    List<House> houses = _housesRepository.GetAllHouses();
    return houses;
  }

  public House GetHouseById(int houseId)
  {
    House house = _housesRepository.GetHouseById(houseId);
    return house;
  }

  public House CreateHouse(House houseData)
  {
    House house = _housesRepository.CreateHouse(houseData);
    return house;
  }

  public string DestroyHouse(int houseId, string userId)
  {
    House house = GetHouseById(houseId);
    if (house.CreatorId != userId)
    {
      throw new Exception("You can not delete a House you did not create");
    }

    _housesRepository.DestroyHouse(houseId);
    return "Your home has been deleted.";
  }
}