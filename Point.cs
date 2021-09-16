Class Point
{
   protected int x, y;
   Point c;
   
   public Point(int x, int y)
   {
      this.x = x;
      this.y = y;
      c = new Point(x+y);
   }
   protected Point (int a)
   {
      this.x = a;
      this.y = a;
   }
   
   public int X
   {
      set
         {
           if (value < 800)
           {  
             x = value;
           }
           else
           {
             x = 799;
           }
         }
      get 
      {
         return x;
      }
  }
  
  public int Y
  {
     set 
        {
           if (value < 600)
              {
                y = value;
              }
           else
              {
                y = 599;
              }
        }
     get
     {
        return x;
     }
 }
 
 public virtual void Stampa()
 {
     Console.WriteLine("X : {0}  Y : {1}", x, y);
 }
 
 public void Sposta(int x, int y)
 {
     this.x += x;
     this.y += y;
 }
 
 public void Sposta(Point punto)
 {
      x += punto.x;
      y += punto.y;
 }
 
 protected void Sposta(int a)
 {
     x += a;
     y += a;
 }
}
}
     
