using Microsoft.Win32.SafeHandles;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace LittleSimWorld.Characters
{
    //this class just holds the clothing. that's it.
    public class CustomizationEditor : Singleton<CustomizationEditor>
    {
        //I know I'm duplicating stuff here, but I'm keeping the Lists to serialize and the Dict to access it
        [Header("Appearance")]
        [SerializeField] List<Hair> _hairs;
        public Dictionary<string, Hair> hairs;

        [SerializeField] List<FacialHair> _facialHairs;
        public Dictionary<string, FacialHair> facialHairs;

        [SerializeField] List<Head> _heads;
        public Dictionary<string, Head> heads;

        [SerializeField] List<Eyes> _eyes;
        public Dictionary<string, Eyes> eyes;

        [SerializeField] List<Mouth> _mouths;
        public Dictionary<string, Mouth> mouths;
        
        [SerializeField] List<Blushes> _blushes;
        public Dictionary<string, Blushes> blushes;


        [Header("Clothing")]
        [SerializeField] List<Hat> _hats;
        public Dictionary<string, Hat> hats;
        
        [SerializeField] List<Glasses> _glasses;
        public Dictionary<string, Glasses> glasses;
        
        [SerializeField] List<Top> _tops;
        public Dictionary<string, Top> tops;


        protected override void Awake()
        {
            base.Awake();

            hairs = _hairs.ToDictionary(item => item.id, item => item);
            facialHairs = _facialHairs.ToDictionary(item => item.id, item => item);
            heads = _heads.ToDictionary(hair => hair.id, hair => hair);
            eyes = _eyes.ToDictionary(item => item.id, item => item);
            mouths = _mouths.ToDictionary(item => item.id, item => item);
            blushes = _blushes.ToDictionary(item => item.id, item => item);

            hats = _hats.ToDictionary(item => item.id, item => item);
            glasses = _glasses.ToDictionary(item => item.id, item => item);
            tops = _tops.ToDictionary(item => item.id, item => item);
        }
    }
}