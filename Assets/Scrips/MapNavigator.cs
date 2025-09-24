using UnityEngine;
using UnityEngine.SceneManagement;

public class MapNavigator : MonoBehaviour
{
   
       public  string[]  sceneNames  ;

       public  GameObject mapCanvasRoot;


    public void  GoToRoomByIndex(int  index)
   {
        if  ( index < 0 || index >= sceneNames.Length )  return 
                   ;

      
          if (mapCanvasRoot != null) mapCanvasRoot.SetActive(false)  ;

           SceneManager.LoadScene( sceneNames[index] )  
            ;
       }
   }
