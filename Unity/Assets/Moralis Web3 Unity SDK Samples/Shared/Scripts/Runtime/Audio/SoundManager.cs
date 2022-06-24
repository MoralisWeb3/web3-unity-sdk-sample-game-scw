using System.Collections.Generic;
using MoralisUnity.Sdk.DesignPatterns.Creational.Singleton.SingletonMonobehaviour;
using UnityEngine;

namespace MoralisUnity.Samples.Shared.Audio
{
	/// <summary>
	/// Maintain a list of AudioSources and play the next 
	/// AudioClip on the first available AudioSource.
	/// </summary>
	public class SoundManager : SingletonMonobehaviour<SoundManager>
	{
		// Properties -------------------------------------
		
		// Fields -----------------------------------------
		[SerializeField]
		private List<AudioClip> _audioClips = new List<AudioClip>();

		[SerializeField]
		private List<AudioSource> _audioSources = new List<AudioSource>();

		// Unity Methods ----------------------------------
		
		
		// General Methods --------------------------------
		/// <summary>
		/// Play the AudioClip by index.
		/// </summary>
		public void PlayAudioClip(int index)
		{
			PlayAudioClip(_audioClips[index]);
		}

		
		/// <summary>
		/// Play the AudioClip by reference.
		/// If all sources are occupied, nothing will play.
		/// </summary>
		public void PlayAudioClip(AudioClip audioClip)
		{
			foreach (AudioSource audioSource in _audioSources)
			{
				if (!audioSource.isPlaying)
				{
					audioSource.clip = audioClip;
					audioSource.Play();
					return;
				}
			}
		}
		
		
		// Event Handlers ---------------------------------

	}
}