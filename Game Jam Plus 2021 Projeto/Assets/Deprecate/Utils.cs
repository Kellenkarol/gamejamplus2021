using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utils
{
    /*public class Grid
    {
        private int _width;
        private int _height;
        private int[,] _grid;
        private TextMesh[,] _gridDebugTextMesh;
        private float _cellSize;

        public Grid(int width,int height,float cellSize = 10)
        {
            this._width = width;
            this._height = height;
            this._cellSize = cellSize;
            _grid = new int[this._width,this._height];
        }

        public void DrawGrid(Color colorLine, bool showValue = true,float time=Mathf.Infinity)
        {
            for (int x =0;x<_grid.GetLength(0); x++)
            {
                for (int y = 0; y < _grid.GetLength(1); y++)

                {
                    Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x, y + 1), colorLine, time);
                    Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x+1, y), colorLine, time);
                    if (showValue)
                    {
                        //_gridDebugTextMesh[x,y] = UtilClass.CreateWorldText(""+newValue,null,new Vector3(x*_cellSize,y*_cellSize),12);
                    }
                }
            }
            Debug.DrawLine(GetWorldPosition(0, _height), GetWorldPosition(_width,_height), colorLine, time);
            Debug.DrawLine(GetWorldPosition(_width, 0), GetWorldPosition(_width, _height), colorLine, time);
        }

        public void DrawGridCenter(Color colorLine, bool showValue = true, float time = Mathf.Infinity)
        {
            for (int x = 0; x < _grid.GetLength(0); x++)
            {
                for (int y = 0; y < _grid.GetLength(1); y++)

                {
                    Debug.DrawLine(GetCenterWorldPosition(x, y), GetCenterWorldPosition(x, y + 1), colorLine, time);
                    Debug.DrawLine(GetCenterWorldPosition(x, y), GetCenterWorldPosition(x + 1, y), colorLine, time);
                    SetValue(x, y, 0,showValue);
                }
            }
            Debug.DrawLine(GetCenterWorldPosition(0, _height), GetCenterWorldPosition(_width, _height), colorLine, time);
            Debug.DrawLine(GetCenterWorldPosition(_width, 0), GetCenterWorldPosition(_width, _height), colorLine, time);
        }
        public Vector3 GetWorldPosition(int x,int y)
        {
            return new Vector3(x, y) * _cellSize;
        }

        public Vector3 GetCenterWorldPosition(float x, float y)
        {
            return new Vector3(x - (_cellSize / 2), y - (_cellSize / 2)) * _cellSize;
        }

        public void SetValue(int x, int y, int newValue,bool showValue=true)
        {
            bool errorAlert = false;
            if(x<0 ||x>= _width)
            {
                int widthMens = _width - 1;
                Debug.LogError("Invalid x valor please pick a number between: 0 and " + widthMens + " grid width value.");
                errorAlert=true;
            }
            if (y < 0 || y >= _height)
            {
                int heightMens = _height - 1;
                Debug.LogError("Invalid y valor please pick a number between: 0 and " + heightMens + " grid height value.");
                errorAlert=true;
            }
            if (errorAlert)
                return;
            _grid[x, y] = newValue;
                
        }  

    }*/

    /*public class UtilClass
    {
        public static TextMesh CreateWorldText(string text, Transform parent = null, Vector3 localPosition = default(Vector3), int fontSize = 40, Color? color = null, TextAnchor textAnchor = TextAnchor.MiddleCenter, TextAlignment textAlignment = TextAlignment.Left, int sortingOrder = 0)
        {
            if (color == null) color = Color.white;
            return CreateWorldText(parent, text, localPosition, fontSize, (Color)color, textAnchor, textAlignment, sortingOrder);
        }

        // Create Text in the World
        public static TextMesh CreateWorldText(Transform parent, string text, Vector3 localPosition, int fontSize, Color color, TextAnchor textAnchor, TextAlignment textAlignment, int sortingOrder)
        {
            GameObject gameObject = new GameObject("World_Text", typeof(TextMesh));
            Transform transform = gameObject.transform;
            transform.SetParent(parent, false);
            transform.localPosition = localPosition;
            TextMesh textMesh = gameObject.GetComponent<TextMesh>();
            textMesh.anchor = textAnchor;
            textMesh.alignment = textAlignment;
            textMesh.text = text;
            textMesh.fontSize = fontSize;
            textMesh.color = color;
            textMesh.GetComponent<MeshRenderer>().sortingOrder = sortingOrder;
            return textMesh;
        }
    }*/

    [System.Serializable]
    public class Array<T> {
        [SerializeField] T[] array;
        [SerializeField] bool arrayCicle;
        public Array(int _lenght, bool _arrayCicle=false){
            this.array = new T[_lenght];
            this.arrayCicle = _arrayCicle;
        }
        public T ChangeNextElement(ref int position)
        {
            position++;
            if (position == array.Length)
            {
                if (arrayCicle)
                    position = 0;
                else
                    position--;
            }
                
            return array[position];
        }
        public T ChangePreviousElement(ref int position)
        {
            position--;;
            if (position < 0)
            {
                if (arrayCicle)
                    position = array.Length - 1;
                else
                    position++;
            }
            return array[position];
        }
        public T GetElement(int position)
        {
            return array[position];
        }

        public void AddElementPosition(T element,int position)
        {
            if(position>=0 && position <= array.Length)
            {
                array[position] = element;
            }
            else
            {
                Debug.LogError("Position error");
            }
        }

        public void RemoveElementPosition(int position)
        {
            if (position >= 0 && position < array.Length)
            {
                array[position] = default(T);
            }
            else
            {
                Debug.LogError("Position error");
            }
        }
        public int GetArrayLenght()
        {
            return array.Length;
        }

        public bool GetArrayCicle()
        {
            return arrayCicle;
        }
    }
}

