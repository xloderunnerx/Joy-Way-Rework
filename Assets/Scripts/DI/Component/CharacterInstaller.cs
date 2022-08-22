using Character.Component;
using Core.Input;
using Sirenix.Serialization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
namespace DI
{
    public class CharacterInstaller : MonoInstaller
    {
        [SerializeField] private CharacterInput characterInput;
        public override void InstallBindings()
        {
            Container.Bind<CharacterInput>().FromInstance(characterInput).AsSingle();
        }
    }
}