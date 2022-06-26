using DG.Tweening;
using System.Collections.Generic;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using UnityEngine.UI;

namespace MoralisUnity.Samples.Shared.Utilities
{
   /// <summary>
   /// Store commonly reused functionality 
   /// for programmatic animation (tweening)
   /// </summary>
   public static class TweenHelper
   {
      //  Other Methods --------------------------------

      /// <summary>
      /// Fades opacity of a list of 2D objects over time, in series.
      /// </summary>
      public static void CanvasGroupsDoFade(List<CanvasGroup> canvasGroups, float fromAlpha, float toAlpha, 
               float duration, float delayStart, float delayDelta)
      {

         float delay = delayStart;

         foreach (CanvasGroup canvasGroup in canvasGroups)
         {
            // Fade out immediately
            canvasGroup.DOFade(fromAlpha, 0);

            // Fade in slowly
            canvasGroup.DOFade(toAlpha, duration)
               .SetDelay(delay);

            delay += delayDelta;
         }
      }

      /// <summary>
      /// Fades 2D Image
      /// </summary>
      public static void ImageDoFade(Image image, float fromAlpha, float toAlpha, 
         float duration, float delayStart)
      {
         // Fade out immediately
         image.DOFade(fromAlpha, 0);
         
         // Fade in slowly
         image.DOFade(toAlpha, duration)
            .SetDelay(delayStart);
      }
      
      /// <summary>
      /// Fades opacity of a 3D Renderer via <see cref="Renderer"/> 
      /// </summary>
      public static void RenderersDoFade(List<Renderer> renderers, float fromAlpha, float toAlpha, 
         float duration, float delayStart)
      {
         foreach (Renderer r in renderers)
         {
            foreach (Material m in r.materials)
            {
               m.DOFade(fromAlpha, 0);
               m.DOFade(toAlpha, duration)
                  .SetDelay(delayStart);
            }
         }
      }

      /// <summary>
      /// Changes color of a 3D object temporarily via <see cref="Renderer"/> 
      /// (E.g. Flicker red to indicate taking damage)
      /// </summary>
      public static void RenderersDoColorFlicker(List<Renderer> renderers, Color color, 
         float duration, float delayStart)
      {
         foreach (Renderer r in renderers)
         {
            foreach (Material m in r.materials)
            {
               Color oldColor = m.color;
               m.DOColor(color, duration)
                  .SetDelay(delayStart)
                  .OnComplete(() =>
               {
                  m.color = oldColor;
               });
            }
         }
      }

      /// <summary>
      /// Moves a <see cref="GameObject"/>
      /// </summary>
      public static  TweenerCore<Vector3, Vector3, VectorOptions> TransformDOBlendableMoveBy(GameObject targetGo, Vector3 fromPosition, Vector3 toPosition, 
         float duration, float delayStart)
      {
         targetGo.transform.position = fromPosition;
         
         return targetGo.transform.DOMove(toPosition, duration)
            .SetDelay(delayStart);
      }
      
      /// <summary>
      /// Scales a <see cref="GameObject"/>
      /// </summary>
      public static TweenerCore<Vector3, Vector3, VectorOptions> TransformDoScale(GameObject targetGo, Vector3 fromScale, Vector3 toScale, 
          float duration, float delayStart)
      {
         targetGo.transform.localScale = fromScale;

         return targetGo.transform.DOScale(toScale, duration)
            .SetDelay(delayStart);
      }

      public static void GameObjectFallsIntoPosition(GameObject go, Vector3 initialPositionOffset, float duration)
      {
         Vector3 fromPosition = go.transform.position + initialPositionOffset;
         TransformDOBlendableMoveBy(go, fromPosition, go.transform.position, duration, 0)
            .SetEase(Ease.InSine);
      }
      
      public static void GameObjectSpawns(GameObject go, float duration)
      {
         Vector3 toScale = go.transform.lossyScale;
         TransformDoScale(go, new Vector3(0,0,0), toScale, duration, 0)
            .SetEase(Ease.OutBounce);
      }
      
      public static void GameObjectDespawns(GameObject go, float duration)
      {
         Vector3 fromScale = go.transform.lossyScale;
         TransformDoScale(go, fromScale,new Vector3(0,0,0), duration, 0)
            .SetEase(Ease.OutBounce);
      }
   }
}
