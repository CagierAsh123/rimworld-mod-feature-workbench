using RimWorld;
using Verse;

namespace TraitWorkbench
{
    public class CompProperties_TraitItem : CompProperties
    {
        public string traitDefName;
        public int traitDegree;
        
        public CompProperties_TraitItem()
        {
            compClass = typeof(CompTraitItem);
        }
    }

    public class CompTraitItem : ThingComp
    {
        public TraitDef TraitDef => DefDatabase<TraitDef>.GetNamedSilentFail(((CompProperties_TraitItem)props).traitDefName);
        public int TraitDegree => ((CompProperties_TraitItem)props).traitDegree;
        
        public void SetTrait(TraitDef newTraitDef, int newDegree)
        {
            var compProps = (CompProperties_TraitItem)props;
            compProps.traitDefName = newTraitDef?.defName;
            compProps.traitDegree = newDegree;
        }
        
        public override string CompInspectStringExtra()
        {
            return TraitDef != null ? "包含特性: " + TraitDef.LabelCap : "空白胶囊";
        }
    }
}