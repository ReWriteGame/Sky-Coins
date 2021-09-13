using UnityEngine;


public class ParallaxScript : MonoBehaviour
{
    public float backgroundSize;// размер картинки в метрах(кубиках) на карте = (раземеру картинки в px / размер метрах(100 по дефолту) * scale(масштаб в сцене)) 2200px / 100 * 1 = 22метра

    public Transform mainCamera;
    private Transform[] layers;
    public float viewZone = 10;
    private int leftIndex;
    private int rightIndex;


    private void Start()
    {
        layers = new Transform[transform.childCount];// количество дочерних элементов

        for (int i = 0; i < transform.childCount; i++)
        {
            layers[i] = transform.GetChild(i);
        }

        leftIndex = 0 ;
        rightIndex = layers.Length - 1;
    }

    private void Update()
    {
        if (mainCamera.position.x < (layers[leftIndex].transform.position.x + viewZone))// движение в лево
        {
            scrollLeft();
        }
        if (mainCamera.position.x > (layers[rightIndex].transform.position.x - viewZone))// движение в право
        {
            scrollRight();
        }
    }


    private void scrollLeft()
    {
        layers[rightIndex].position = new Vector3(layers[leftIndex].position.x - backgroundSize, layers[rightIndex].position.y, layers[rightIndex].position.z);
        leftIndex = rightIndex;
        rightIndex--;

        if (rightIndex < 0)
            rightIndex = layers.Length - 1;
        
    }

    private void scrollRight()
    {
        layers[leftIndex].position = new Vector3(layers[rightIndex].position.x + backgroundSize, layers[leftIndex].position.y, layers[leftIndex].position.z);// перенос левого куска в право по x c cохранение y и z
        rightIndex = leftIndex;
        leftIndex++;

        if (leftIndex == layers.Length) 
            leftIndex = 0;
        
    }


// Примичание: место старта камеры будет влиять на то как будет отображаться бп если поставить прямямо по центру бг все будет ок если нет могут быть проблемы со смещением бг

}









