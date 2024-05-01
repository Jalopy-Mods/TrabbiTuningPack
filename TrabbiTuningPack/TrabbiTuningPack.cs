using JaLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace TrabbiTuningPack
{
    public class TrabbiTuningPack : Mod
    {
        public override string ModID => "TrabbiTuningPack";
        public override string ModName => "Trabbi Tuning Pack";
        public override string ModAuthor => "Leaxx, VanilleVaschnille";
        public override string ModDescription => "Adds rear louvres, eyelids and sideskirts to the Laika!\n\nModels made by VanilleVaschnille";
        public override string ModVersion => "1.0.0";
        public override string GitHubLink => "https://github.com/Jalopy-Mods/TrabbiTuningPack";
        public override WhenToInit WhenToInit => WhenToInit.InGame;
        public override List<(string, string, string)> Dependencies => new List<(string, string, string)>()
        {
            ("JaLoader", "Leaxx", "2.0.1")
        };

        public override bool UseAssets => true;

        private GameObject eyelidsObject;
        private GameObject rearLouvresObject;

        public override void Start()
        {
            base.Start();

            ModHelper.Instance.laika.transform.Find("TweenHolder/Frame/FR_LightCap").GetComponent<MeshRenderer>().enabled = false;
        }

        public override void CustomObjectsRegistration()
        {
            base.CustomObjectsRegistration();

            eyelidsObject = LoadAsset<GameObject>("eyelids", "Eyelids", "", ".prefab");
            eyelidsObject = Instantiate(eyelidsObject, ModHelper.Instance.laika.transform.Find("TweenHolder/Frame"));
            eyelidsObject.transform.localPosition = Vector3.zero;
            eyelidsObject.transform.localRotation = Quaternion.identity;
            eyelidsObject.transform.localScale = Vector3.one;

            ModHelper.Instance.CreateIconForExtra(eyelidsObject, new Vector3(0.15f, 0.35f, 0), new Vector3(0.2f, 0.2f, 0.2f), new Vector3(0, 90, 0), "Eyelids");

            CustomObjectsManager.Instance.RegisterObject(ModHelper.Instance.CreateExtraObject(eyelidsObject, BoxSizes.Small, "Eyelids", "Eyelids for your headlights, for an aggressive look!", 40, 1, "Eyelids", AttachExtraTo.Body), "Eyelids");
        
            rearLouvresObject = LoadAsset<GameObject>("rearlouvres", "RearLouvres", "", ".prefab");
            rearLouvresObject = Instantiate(rearLouvresObject, ModHelper.Instance.laika.transform.Find("TweenHolder/Frame"));

            ModHelper.Instance.CreateIconForExtra(rearLouvresObject, new Vector3(0, 0.1f, 0), new Vector3(20, 20, 20), new Vector3(-90, -200, 110), "RearLouvres");

            CustomObjectsManager.Instance.RegisterObject(ModHelper.Instance.CreateExtraObject(rearLouvresObject, BoxSizes.Big, "Rear Louvres", "Adds rear louvres to your Laika, for a sporty look!", 60, 3, "Rear Louvres", AttachExtraTo.Body), "RearLouvres");
        }
    }
}
