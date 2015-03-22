using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeAndTravel
{
    class myInteractionManager : InteractionManager
    {
        protected override void HandlePersonCommand(string[] commandWords, Person actor)
        {
            switch (commandWords[1])
            {
                case "gather":
                    HandleGatherInteraction(commandWords, actor);
                    break;
                case "craft":
                    HandleCraftUpInteraction(commandWords, actor);
                    break;
                default:
                    base.HandlePersonCommand(commandWords, actor);
                    break;
            }
        }

        private void HandleGatherInteraction(string[] commandWords, Person actor)
        {
            if (actor.Location.LocationType == LocationType.Forest)
            {
                var asd = actor.ListInventory().Find(x => x.ItemType == ItemType.Weapon);
                if (actor.ListInventory().Find(x => x.ItemType == ItemType.Weapon) != null)
                {
                    AddToPerson(actor, new Wood(commandWords[2]));
                }
            }
            else if (actor.Location.LocationType == LocationType.Mine)
            {
                if (actor.ListInventory().Find(x => x.ItemType == ItemType.Armor) != null)
                {
                    AddToPerson(actor, new Iron(commandWords[2]));
                }
            }
        }

        private void HandleCraftUpInteraction(string[] commandWords, Person actor)
        {
            var Iron = actor.ListInventory().Find(x => x.ItemType == ItemType.Iron);
            var Wood = actor.ListInventory().Find(x => x.ItemType == ItemType.Wood);
            if (Iron != null && Wood != null && commandWords[2] == "weapon")
            {
                AddToPerson(actor, new Weapon(commandWords[3]));
            }
            else if (Iron != null && commandWords[2] == "armor")
            {
                AddToPerson(actor, new Armor(commandWords[3]));
            }
        }

        protected override Location CreateLocation(string locationTypeString, string locationName)
        {
            Location location = null;
            switch (locationTypeString)
            {
                case "mine":
                    location = new Mine(locationName);
                    break;
                case "forest":
                    location = new Forest(locationName);
                    break;
                default:
                    location = base.CreateLocation(locationTypeString, locationName);
                    break;
            }
            return location;
        }

        protected override Item CreateItem(string itemTypeString, string itemNameString, Location itemLocation, Item item)
        {
            switch (itemTypeString)
            {
                case "weapon":
                    item = new Weapon(itemNameString, itemLocation);
                    break;
                case "wood":
                    item = new Wood(itemNameString, itemLocation);
                    break;
                case "iron":
                    item = new Iron(itemNameString, itemLocation);
                    break;
                default:
                    item = base.CreateItem(itemTypeString, itemNameString, itemLocation, item);
                    break;
            }
            return item;
        }

        protected override Person CreatePerson(string personTypeString, string personNameString, Location personLocation)
        {
            Person person = null;
            switch (personTypeString)
            {
                case "merchant":
                    person = new Merchant(personNameString, personLocation);
                    break;
                default:
                    person = base.CreatePerson(personTypeString, personNameString, personLocation);
                    break;
            }
            return person;
        }
    }
}
