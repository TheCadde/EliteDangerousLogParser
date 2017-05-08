using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// ReSharper disable InconsistentNaming

namespace EDLogParser.LogEntries {
    public class Fileheader : LogEntryBase {
        public double part { get; set; }
        public string language { get; set; }
        public string gameversion { get; set; }
        public string build { get; set; }

        public Fileheader(Dictionary<string, object> rawData) : base(rawData) {
        }
    }

    public class Cargo : LogEntryBase {
        // TODO: Populate
        public List<CargoInventory> Inventory { get; set; }

        public Cargo(Dictionary<string, object> rawData) : base(rawData) {
        }
    }

    public class CargoInventory {
        public string Name { get; set; }
        public double Count { get; set; }
    }

    public class Loadout : LogEntryBase {
        public string Ship { get; set; }
        public double ShipID { get; set; }
        public string ShipName { get; set; }
        public string ShipIdent { get; set; }
        // TODO: Populate
        public List<LoadoutModule> Modules { get; set; }

        public Loadout(Dictionary<string, object> rawData) : base(rawData) {
        }
    }

    public class LoadoutModule {
        public string Slot { get; set; }
        public string Item { get; set; }
        public string EngineerBlueprint { get; set; }
        public bool On { get; set; }
        public double Priority { get; set; }
        public double Health { get; set; }
        public double Value { get; set; }
        public double AmmoInClip { get; set; }
        public double EngineerLevel { get; set; }
        public double AmmoInHopper { get; set; }
    }

    public class Materials : LogEntryBase {
        // TODO: Populate
        public List<CargoInventory> Raw { get; set; }
        // TODO: Populate
        public List<CargoInventory> Manufactured { get; set; }
        // TODO: Populate
        public List<CargoInventory> Encoded { get; set; }

        public Materials(Dictionary<string, object> rawData) : base(rawData) {
        }
    }

    public class LoadGame : LogEntryBase {
        public string Commander { get; set; }
        public string Group { get; set; }
        public string Ship { get; set; }
        public double ShipID { get; set; }
        public string ShipName { get; set; }
        public string ShipIdent { get; set; }
        public double FuelLevel { get; set; }
        public double FuelCapacity { get; set; }
        public string GameMode { get; set; }
        public double Credits { get; set; }
        public double Loan { get; set; }

        public LoadGame(Dictionary<string, object> rawData) : base(rawData) {
        }
    }

    public class Rank : LogEntryBase {
        public double Combat { get; set; }
        public double Trade { get; set; }
        public double Explore { get; set; }
        public double Empire { get; set; }
        public double Federation { get; set; }
        public double CQC { get; set; }

        public Rank(Dictionary<string, object> rawData) : base(rawData) {
        }
    }

    public class Progress : LogEntryBase {
        public double Combat { get; set; }
        public double Trade { get; set; }
        public double Explore { get; set; }
        public double Empire { get; set; }
        public double Federation { get; set; }
        public double CQC { get; set; }

        public Progress(Dictionary<string, object> rawData) : base(rawData) {
        }
    }

    public class Location : LogEntryBase {
        public bool Docked { get; set; }
        public string StationName { get; set; }
        public string StationType { get; set; }
        public string StarSystem { get; set; }
        public List<double> StarPos { get; set; }
        public string SystemAllegiance { get; set; }
        public string SystemEconomy { get; set; }
        public string SystemEconomy_Localised { get; set; }
        public string SystemGovernment { get; set; }
        public string SystemGovernment_Localised { get; set; }
        public string SystemSecurity { get; set; }
        public string SystemSecurity_Localised { get; set; }
        public string Body { get; set; }
        public string BodyType { get; set; }
        // TODO: Populate
        public List<Faction> Factions { get; set; }
        public string SystemFaction { get; set; }
        public string FactionState { get; set; }

        public Location(Dictionary<string, object> rawData) : base(rawData) {
        }
    }

    public class Faction {
        public string Name { get; set; }
        public string FactionState { get; set; }
        public string Government { get; set; }
        public double Influence { get; set; }
        public string Allegiance { get; set; }
    }

    public class Docked : LogEntryBase {
        public string StationName { get; set; }
        public string StationType { get; set; }
        public string StarSystem { get; set; }
        public string StationFaction { get; set; }
        public string FactionState { get; set; }
        public string StationGovernment { get; set; }
        public string StationGovernment_Localised { get; set; }
        public string StationAllegiance { get; set; }
        public string StationEconomy { get; set; }
        public string StationEconomy_Localised { get; set; }
        public double DistFromStarLS { get; set; }

        public Docked(Dictionary<string, object> rawData) : base(rawData) {
        }
    }

    public class ReceiveText : LogEntryBase {
        public string From { get; set; }
        public string From_Localised { get; set; }
        public string Message { get; set; }
        public string Message_Localised { get; set; }
        public string Channel { get; set; }

        public ReceiveText(Dictionary<string, object> rawData) : base(rawData) {
        }
    }

    public class SellExplorationData : LogEntryBase {
        public List<string> Systems { get; set; }
        // TODO: Populate
        // TODO: Investigate why this wasn't detected as string
        public List<string> Discovered { get; set; }
        public double BaseValue { get; set; }
        public double Bonus { get; set; }

        public SellExplorationData(Dictionary<string, object> rawData) : base(rawData) {
        }
    }

    public class Promotion : LogEntryBase {
        public double Explore { get; set; }
        public double Federation { get; set; }
        public double Trade { get; set; }
        public double Combat { get; set; }

        public Promotion(Dictionary<string, object> rawData) : base(rawData) {
        }
    }

    public class MissionAccepted : LogEntryBase {
        public string Faction { get; set; }
        public string Name { get; set; }
        public string DestinationSystem { get; set; }
        public string Commodity { get; set; }
        public string Commodity_Localised { get; set; }
        public double Count { get; set; }
        public string DestinationStation { get; set; }
        public string Expiry { get; set; }
        public string Influence { get; set; }
        public string Reputation { get; set; }
        public double MissionID { get; set; }
        public double KillCount { get; set; }
        public double PassengerCount { get; set; }
        public bool PassengerVIPs { get; set; }
        public bool PassengerWanted { get; set; }
        public string PassengerType { get; set; }
        public string TargetType { get; set; }
        public string TargetType_Localised { get; set; }
        public string Target { get; set; }
        public string TargetFaction { get; set; }

        public MissionAccepted(Dictionary<string, object> rawData) : base(rawData) {
        }
    }

    public class ModuleRetrieve : LogEntryBase {
        public string Slot { get; set; }
        public string RetrievedItem { get; set; }
        public string RetrievedItem_Localised { get; set; }
        public string Ship { get; set; }
        public double ShipID { get; set; }
        public string SwapOutItem { get; set; }
        public string SwapOutItem_Localised { get; set; }
        public double Cost { get; set; }
        public string EngineerModifications { get; set; }


        public ModuleRetrieve(Dictionary<string, object> rawData) : base(rawData) {
        }
    }

    public class ShieldState : LogEntryBase {
        public bool ShieldsUp { get; set; }

        public ShieldState(Dictionary<string, object> rawData) : base(rawData) {
        }
    }

    public class BuyDrones : LogEntryBase {
        public string Type { get; set; }
        public double Count { get; set; }
        public double BuyPrice { get; set; }
        public double TotalCost { get; set; }

        public BuyDrones(Dictionary<string, object> rawData) : base(rawData) {
        }
    }

    public class Undocked : LogEntryBase {
        public string StationName { get; set; }
        public string StationType { get; set; }

        public Undocked(Dictionary<string, object> rawData) : base(rawData) {
        }
    }

    public class Scanned : LogEntryBase {
        public string ScanType { get; set; }

        public Scanned(Dictionary<string, object> rawData) : base(rawData) {
        }
    }

    public class StartJump : LogEntryBase {
        public string JumpType { get; set; }
        public string StarSystem { get; set; }
        public string StarClass { get; set; }

        public StartJump(Dictionary<string, object> rawData) : base(rawData) {
        }
    }

    public class FSDJump : LogEntryBase {
        public string StarSystem { get; set; }
        public List<double> StarPos { get; set; }
        public string SystemAllegiance { get; set; }
        public string SystemEconomy { get; set; }
        public string SystemEconomy_Localised { get; set; }
        public string SystemGovernment { get; set; }
        public string SystemGovernment_Localised { get; set; }
        public string SystemSecurity { get; set; }
        public string SystemSecurity_Localised { get; set; }
        public double JumpDist { get; set; }
        public double FuelUsed { get; set; }
        public double FuelLevel { get; set; }
        // TODO: Populate
        public List<Faction> Factions { get; set; }
        public string SystemFaction { get; set; }
        public string FactionState { get; set; }
        public double BoostUsed { get; set; }

        public FSDJump(Dictionary<string, object> rawData) : base(rawData) {
        }
    }

    public class SupercruiseExit : LogEntryBase {
        public string StarSystem { get; set; }
        public string Body { get; set; }
        public string BodyType { get; set; }

        public SupercruiseExit(Dictionary<string, object> rawData) : base(rawData) {
        }
    }

    public class DockingRequested : LogEntryBase {
        public string StationName { get; set; }

        public DockingRequested(Dictionary<string, object> rawData) : base(rawData) {
        }
    }

    public class DockingGranted : LogEntryBase {
        public double LandingPad { get; set; }
        public string StationName { get; set; }

        public DockingGranted(Dictionary<string, object> rawData) : base(rawData) {
        }
    }

    public class MissionCompleted : LogEntryBase {
        public string Faction { get; set; }
        public string Name { get; set; }
        public double MissionID { get; set; }
        public string DestinationSystem { get; set; }
        public string DestinationStation { get; set; }
        public string Commodity { get; set; }
        public List<CargoInventory> CommodityReward { get; set; }
        public string Commodity_Localised { get; set; }
        public double Reward { get; set; }
        public double Count { get; set; }
        public double KillCount { get; set; }
        public double Donation { get; set; }
        public string TargetType { get; set; }
        public string TargetType_Localised { get; set; }
        public string TargetFaction { get; set; }
        public string Target { get; set; }


        public MissionCompleted(Dictionary<string, object> rawData) : base(rawData) {
        }
    }

    public class RefuelAll : LogEntryBase {
        public double Cost { get; set; }
        public double Amount { get; set; }

        public RefuelAll(Dictionary<string, object> rawData) : base(rawData) {
        }
    }

    public class Scan : LogEntryBase {
        public string BodyName { get; set; }
        public double DistanceFromArrivalLS { get; set; }
        public bool TidalLock { get; set; }
        public string TerraformState { get; set; }
        public string PlanetClass { get; set; }
        public string Atmosphere { get; set; }
        public string AtmosphereType { get; set; }
        public string Volcanism { get; set; }
        public double MassEM { get; set; }
        public double Radius { get; set; }
        public double SurfaceGravity { get; set; }
        public double SurfaceTemperature { get; set; }
        public double SurfacePressure { get; set; }
        public bool Landable { get; set; }
        public List<ScanMaterials> Materials { get; set; }
        public List<ScanMaterials> AtmosphereComposition { get; set; }
        public List<Ring> Rings { get; set; }
        public double SemiMajorAxis { get; set; }
        public double Eccentricity { get; set; }
        public double OrbitalInclination { get; set; }
        public double Periapsis { get; set; }
        public double OrbitalPeriod { get; set; }
        public double RotationPeriod { get; set; }
        public string StarType { get; set; }
        public string ReserveLevel { get; set; }
        public double StellarMass { get; set; }
        public double AbsoluteMagnitude { get; set; }
        public double Age_MY { get; set; }

        public Scan(Dictionary<string, object> rawData) : base(rawData) {
        }
    }

    public class Ring {
        public string Name { get; set; }
        public string RingClass { get; set; }
        public double MassMT { get; set; }
        public double InnerRad { get; set; }
        public double OuterRad { get; set; }
    }

    public class ScanMaterials {
        public string Name { get; set; }
        public double Percent { get; set; }
    }

    public class ApproachSettlement : LogEntryBase {
        public string Name { get; set; }

        public ApproachSettlement(Dictionary<string, object> rawData) : base(rawData) {
        }
    }

    public class SupercruiseEntry : LogEntryBase {
        public string StarSystem { get; set; }

        public SupercruiseEntry(Dictionary<string, object> rawData) : base(rawData) {
        }
    }

    public class MaterialDiscovered : LogEntryBase {
        public string Category { get; set; }
        public string Name { get; set; }
        public double DiscoveryNumber { get; set; }

        public MaterialDiscovered(Dictionary<string, object> rawData) : base(rawData) {
        }
    }

    public class MaterialCollected : LogEntryBase {
        public string Category { get; set; }
        public string Name { get; set; }
        public double Count { get; set; }

        public MaterialCollected(Dictionary<string, object> rawData) : base(rawData) {
        }
    }

    public class USSDrop : LogEntryBase {
        public string USSType { get; set; }
        public string USSType_Localised { get; set; }
        public double USSThreat { get; set; }

        public USSDrop(Dictionary<string, object> rawData) : base(rawData) {
        }
    }

    public class MissionFailed : LogEntryBase {
        public string Name { get; set; }
        public double MissionID { get; set; }

        public MissionFailed(Dictionary<string, object> rawData) : base(rawData) {
        }
    }

    public class CollectCargo : LogEntryBase {
        public string Type { get; set; }
        public bool Stolen { get; set; }

        public CollectCargo(Dictionary<string, object> rawData) : base(rawData) {
        }
    }

    public class EjectCargo : LogEntryBase {
        public string Type { get; set; }
        public double Count { get; set; }
        public bool Abandoned { get; set; }

        public EjectCargo(Dictionary<string, object> rawData) : base(rawData) {
        }
    }

    public class MarketSell : LogEntryBase {
        public string Type { get; set; }
        public double Count { get; set; }
        public double SellPrice { get; set; }
        public double TotalSale { get; set; }
        public double AvgPricePaid { get; set; }
        public bool StolenGoods { get; set; }
        public bool BlackMarket { get; set; }

        public MarketSell(Dictionary<string, object> rawData) : base(rawData) {
        }
    }

    public class ModuleBuy : LogEntryBase {
        public string Slot { get; set; }
        public string SellItem { get; set; }
        public string SellItem_Localised { get; set; }
        public double SellPrice { get; set; }
        public string BuyItem { get; set; }
        public string BuyItem_Localised { get; set; }
        public string StoredItem { get; set; }
        public string StoredItem_Localised { get; set; }
        public double BuyPrice { get; set; }
        public string Ship { get; set; }
        public double ShipID { get; set; }


        public ModuleBuy(Dictionary<string, object> rawData) : base(rawData) {
        }
    }

    public class SendText : LogEntryBase {
        public string To { get; set; }
        public string Message { get; set; }

        public SendText(Dictionary<string, object> rawData) : base(rawData) {
        }
    }

    public class BuyAmmo : LogEntryBase {
        public double Cost { get; set; }

        public BuyAmmo(Dictionary<string, object> rawData) : base(rawData) {
        }
    }

    public class RepairAll : LogEntryBase {
        public double Cost { get; set; }

        public RepairAll(Dictionary<string, object> rawData) : base(rawData) {
        }
    }

    public class ModuleStore : LogEntryBase {
        public string Slot { get; set; }
        public string StoredItem { get; set; }
        public string StoredItem_Localised { get; set; }
        public string EngineerModifications { get; set; }
        public string Ship { get; set; }
        public double ShipID { get; set; }

        public ModuleStore(Dictionary<string, object> rawData) : base(rawData) {
        }
    }

    public class ShipyardSwap : LogEntryBase {
        public string ShipType { get; set; }
        public double ShipID { get; set; }
        public string StoreOldShip { get; set; }
        public double StoreShipID { get; set; }

        public ShipyardSwap(Dictionary<string, object> rawData) : base(rawData) {
        }
    }

    public class ModuleSellRemote : LogEntryBase {
        public double StorageSlot { get; set; }
        public string SellItem { get; set; }
        public string SellItem_Localised { get; set; }
        public double ServerId { get; set; }
        public double SellPrice { get; set; }
        public string Ship { get; set; }
        public double ShipID { get; set; }

        public ModuleSellRemote(Dictionary<string, object> rawData) : base(rawData) {
        }
    }

    public class ShipyardBuy : LogEntryBase {
        public string ShipType { get; set; }
        public double ShipPrice { get; set; }
        public string SellOldShip { get; set; }
        public string StoreOldShip { get; set; }
        public double StoreShipID { get; set; }
        public double SellShipID { get; set; }
        public double SellPrice { get; set; }

        public ShipyardBuy(Dictionary<string, object> rawData) : base(rawData) {
        }
    }

    public class ShipyardNew : LogEntryBase {
        public string ShipType { get; set; }
        public double NewShipID { get; set; }

        public ShipyardNew(Dictionary<string, object> rawData) : base(rawData) {
        }
    }

    public class ModuleSell : LogEntryBase {
        public string Slot { get; set; }
        public string SellItem { get; set; }
        public string SellItem_Localised { get; set; }
        public double SellPrice { get; set; }
        public string Ship { get; set; }
        public double ShipID { get; set; }

        public ModuleSell(Dictionary<string, object> rawData) : base(rawData) {
        }
    }

    public class ModuleSwap : LogEntryBase {
        public string FromSlot { get; set; }
        public string ToSlot { get; set; }
        public string FromItem { get; set; }
        public string FromItem_Localised { get; set; }
        public string ToItem { get; set; }
        public string ToItem_Localised { get; set; }
        public string Ship { get; set; }
        public double ShipID { get; set; }

        public ModuleSwap(Dictionary<string, object> rawData) : base(rawData) {
        }
    }

    public class EscapeInterdiction : LogEntryBase {
        public string Interdictor { get; set; }
        public bool IsPlayer { get; set; }

        public EscapeInterdiction(Dictionary<string, object> rawData) : base(rawData) {
        }
    }

    public class CommitCrime : LogEntryBase {
        public string CrimeType { get; set; }
        public string Faction { get; set; }
        public string Victim { get; set; }
        public double Fine { get; set; }
        public double Bounty { get; set; }

        public CommitCrime(Dictionary<string, object> rawData) : base(rawData) {
        }
    }

    public class DockingDenied : LogEntryBase {
        public string Reason { get; set; }
        public string StationName { get; set; }

        public DockingDenied(Dictionary<string, object> rawData) : base(rawData) {
        }
    }

    public class WingJoin : LogEntryBase {
        // TODO: Populate
        // TODO: Investigate why this wasn't detected as string
        public List<string> Others { get; set; }

        public WingJoin(Dictionary<string, object> rawData) : base(rawData) {
        }
    }

    public class WingAdd : LogEntryBase {
        public string Name { get; set; }

        public WingAdd(Dictionary<string, object> rawData) : base(rawData) {
        }
    }

    public class PayFines : LogEntryBase {
        public double Amount { get; set; }
        public double BrokerPercentage { get; set; }

        public PayFines(Dictionary<string, object> rawData) : base(rawData) {
        }
    }

    public class HeatWarning : LogEntryBase {

        public HeatWarning(Dictionary<string, object> rawData) : base(rawData) {
        }
    }

    public class HullDamage : LogEntryBase {
        public double Health { get; set; }
        public bool PlayerPilot { get; set; }
        public bool Fighter { get; set; }

        public HullDamage(Dictionary<string, object> rawData) : base(rawData) {
        }
    }

    public class WingLeave : LogEntryBase {

        public WingLeave(Dictionary<string, object> rawData) : base(rawData) {
        }
    }

    public class Passengers : LogEntryBase {
        // TODO: Populate
        public List<PassengerManifest> Manifest { get; set; }

        public Passengers(Dictionary<string, object> rawData) : base(rawData) {
        }
    }

    public class PassengerManifest {
        public double MissionID { get; set; }
        public string Type { get; set; }
        public bool VIP { get; set; }
        public bool Wanted { get; set; }
        public double Count { get; set; }
    }

    public class FetchRemoteModule : LogEntryBase {
        public double StorageSlot { get; set; }
        public string StoredItem { get; set; }
        public string StoredItem_Localised { get; set; }
        public double ServerId { get; set; }
        public double TransferCost { get; set; }
        public string Ship { get; set; }
        public double ShipID { get; set; }

        public FetchRemoteModule(Dictionary<string, object> rawData) : base(rawData) {
        }
    }

    public class MiningRefined : LogEntryBase {
        public string Type { get; set; }
        public string Type_Localised { get; set; }

        public MiningRefined(Dictionary<string, object> rawData) : base(rawData) {
        }
    }

    public class Interdicted : LogEntryBase {
        public bool Submitted { get; set; }
        public string Interdictor { get; set; }
        public bool IsPlayer { get; set; }
        public string Faction { get; set; }

        public Interdicted(Dictionary<string, object> rawData) : base(rawData) {
        }
    }

    public class RedeemVoucher : LogEntryBase {
        public string Type { get; set; }
        public double Amount { get; set; }
        public string Faction { get; set; }
        public double BrokerPercentage { get; set; }

        public List<FactionReward> Factions { get; set; }

        public RedeemVoucher(Dictionary<string, object> rawData) : base(rawData) {
        }
    }

    public class FactionReward {
        public string Faction { get; set; }
        public double Amount { get; set; }

    }

    public class Repair : LogEntryBase {
        public string Item { get; set; }
        public double Cost { get; set; }

        public Repair(Dictionary<string, object> rawData) : base(rawData) {
        }
    }

    public class Died : LogEntryBase {
        public string KillerName { get; set; }
        public string KillerShip { get; set; }
        public string KillerRank { get; set; }

        public Died(Dictionary<string, object> rawData) : base(rawData) {
        }
    }

    public class Resurrect : LogEntryBase {
        public string Option { get; set; }
        public double Cost { get; set; }
        public bool Bankrupt { get; set; }

        public Resurrect(Dictionary<string, object> rawData) : base(rawData) {
        }
    }

    public class EngineerCraft : LogEntryBase {
        public string Engineer { get; set; }
        public string Blueprint { get; set; }
        public double Level { get; set; }
        // TODO: Populate
        public List<CargoInventory> Ingredients { get; set; }

        public EngineerCraft(Dictionary<string, object> rawData) : base(rawData) {
        }
    }

    public class EngineerApply : LogEntryBase {
        public string Engineer { get; set; }
        public string Blueprint { get; set; }
        public double Level { get; set; }

        public EngineerApply(Dictionary<string, object> rawData) : base(rawData) {
        }
    }

    public class MissionAbandoned : LogEntryBase {
        public string Name { get; set; }
        public double MissionID { get; set; }

        public MissionAbandoned(Dictionary<string, object> rawData) : base(rawData) {
        }
    }

    public class FuelScoop : LogEntryBase {
        public double Scooped { get; set; }
        public double Total { get; set; }

        public FuelScoop(Dictionary<string, object> rawData) : base(rawData) {
        }
    }

    public class MarketBuy : LogEntryBase {
        public string Type { get; set; }
        public double Count { get; set; }
        public double BuyPrice { get; set; }
        public double TotalCost { get; set; }

        public MarketBuy(Dictionary<string, object> rawData) : base(rawData) {
        }
    }

    public class DataScanned : LogEntryBase {
        public string Type { get; set; }

        public DataScanned(Dictionary<string, object> rawData) : base(rawData) {
        }
    }

    public class Bounty : LogEntryBase {
        // TODO: Populate
        public List<BountyReward> Rewards { get; set; }
        public string Target { get; set; }
        public double TotalReward { get; set; }
        public string VictimFaction { get; set; }
        public string VictimFaction_Localised { get; set; }

        public Bounty(Dictionary<string, object> rawData) : base(rawData) {
        }
    }

    public class BountyReward {
        public string Faction { get; set; }
        public double Reward { get; set; }
    }

    public class PayLegacyFines : LogEntryBase {
        public double Amount { get; set; }
        public double BrokerPercentage { get; set; }

        public PayLegacyFines(Dictionary<string, object> rawData) : base(rawData) {
        }
    }

    public class EngineerProgress : LogEntryBase {
        public string Engineer { get; set; }
        public string Progress { get; set; }
        public double Rank { get; set; }

        public EngineerProgress(Dictionary<string, object> rawData) : base(rawData) {
        }
    }

    public class ShipyardSell : LogEntryBase {
        public string ShipType { get; set; }
        public double SellShipID { get; set; }
        public double ShipPrice { get; set; }

        public ShipyardSell(Dictionary<string, object> rawData) : base(rawData) {
        }
    }

    public class Synthesis : LogEntryBase {
        public string Name { get; set; }
        public List<CargoInventory> Materials { get; set; }

        public Synthesis(Dictionary<string, object> rawData) : base(rawData) {
        }
    }

    public class Interdiction : LogEntryBase {
        public bool Success { get; set; }
        public bool IsPlayer { get; set; }
        public string Faction { get; set; }

        public Interdiction(Dictionary<string, object> rawData) : base(rawData) {
        }
    }

    public class Screenshot : LogEntryBase {
        public string Filename { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public string System { get; set; }
        public string Body { get; set; }

        public Screenshot(Dictionary<string, object> rawData) : base(rawData) {
        }
    }

    public class JetConeBoost : LogEntryBase {
        public double BoostValue { get; set; }

        public JetConeBoost(Dictionary<string, object> rawData) : base(rawData) {
        }
    }

}
