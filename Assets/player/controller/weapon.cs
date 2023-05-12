using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon 
{

    float launchDistance;
    float damage;
    float range;
    float angleFlyingDirection; //Ángula en la que vuela el personaje cuando se apunta abajo con un arma en grados.
    
    public Weapon(float launchDistance, float damage, float range, float angleflyingDirection)
    {
        this.launchDistance = launchDistance;
        this.damage = damage;
        this.range = range;
        this.angleFlyingDirection = Mathf.Sin(angleflyingDirection * Mathf.Deg2Rad);
    }
    
    public abstract void shoot();

    /**Cálcula la dirección del vector y la devuelve respecto a la rotación del axis z y la devuelve normalizada
     * @rotation rotación del vector z (la rotacción de donde apunta el personaje) en grados
     * 
     */
    Vector3 getFlyingDirection(Vector3 facingDirection)
    {
        Vector3 facing = new Vector3(facingDirection.x,0, facingDirection.z);
        facing.Normalize();
        facing *= Mathf.Abs(1.0f - angleFlyingDirection);
        facing.z = angleFlyingDirection;
        return facing;

    }
    /**Cálcula la dirección del vector y la devuelve respecto a la rotación de la axis y 
     * @rotation rotación del vector y (la rotacción de donde apunta el personaje) en grados
     * 
     */
    Vector3 getFlyingDirection(float rotation)
    {
        return new Vector3(Mathf.Abs(1-angleFlyingDirection) * Mathf.Cos(rotation * Mathf.Deg2Rad), angleFlyingDirection, Mathf.Abs(1-angleFlyingDirection) * Mathf.Sin(rotation * Mathf.Deg2Rad));
    }
}
