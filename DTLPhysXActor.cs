using System;
using System.Collections.Generic;
using System.Text;
using OpenMetaverse;
using OpenSim.Framework;
using OpenSim.Region.Physics.Manager;
using StillDesign.PhysX;
using Vector3X = SlimDX.Vector3;


namespace DeepThink.PhysX
{
	class DTLPhysXActor : PhysicsActor 
	{
	    private Actor actor;
	    private Scene scene;
	    private IMesher mesher;

	    private uint localOpenSimID;

	    public DTLPhysXActor(Scene scene, IMesher mesher)
	    {
	        this.scene = scene;
	        this.mesher = mesher;
	    }

	    private ShapeDescription ToShape(PrimitiveBaseShape baseShape)
        {
            ConvexShapeDescription convexShapeDescription = new ConvexShapeDescription();
            //ShapeDescription retval = new BodyDescription()
        }

	    #region Overrides of PhysicsActor

	    public override bool Stopped
	    {
	        get
	        {
	            return actor.IsSleeping;
	        }
	    }

	    public override PhysicsVector Size
	    {
	        get
	        {
	            SlimDX.Vector3 extents = actor.Shapes[0].WorldSpaceBounds.Extents;
	            PhysicsVector size = new PhysicsVector(extents.X, extents.Y, extents.Z);
	            return size;
	        }
	        set
	        {
                //TODO: Implement me.
	        }
	    }

	    public override PrimitiveBaseShape Shape
	    {
	        set
	        {
	            ActorDescription desc = actor.SaveToActorDescription();
                //scene.
                actor.Dispose();

                desc.Shapes.Clear();
	            desc.Shapes.Add(ToShape(value));

	            actor = scene.CreateActor(desc);
	        }
	    }

	    public override uint LocalID
	    {
            set { localOpenSimID = value; }
	    }

	    public override bool Grabbed
	    {
	        set { throw new System.NotImplementedException(); }
	    }

	    public override bool Selected
	    {
	        set { throw new System.NotImplementedException(); }
	    }

	    public override void CrossingFailure()
	    {
	        throw new System.NotImplementedException();
	    }

	    public override void link(PhysicsActor obj)
	    {
	        throw new System.NotImplementedException();
	    }

	    public override void delink()
	    {
	        throw new System.NotImplementedException();
	    }

	    public override void LockAngularMotion(PhysicsVector axis)
	    {
	        throw new System.NotImplementedException();
	    }

	    public override PhysicsVector Position
	    {
	        get { throw new System.NotImplementedException(); }
	        set { throw new System.NotImplementedException(); }
	    }

	    public override float Mass
	    {
	        get { throw new System.NotImplementedException(); }
	    }

	    public override PhysicsVector Force
	    {
	        get { throw new System.NotImplementedException(); }
	        set { throw new System.NotImplementedException(); }
	    }

	    public override int VehicleType
	    {
	        get { throw new System.NotImplementedException(); }
	        set { throw new System.NotImplementedException(); }
	    }

	    public override void VehicleFloatParam(int param, float value)
	    {
	        throw new System.NotImplementedException();
	    }

	    public override void VehicleVectorParam(int param, PhysicsVector value)
	    {
	        throw new System.NotImplementedException();
	    }

	    public override void VehicleRotationParam(int param, Quaternion rotation)
	    {
	        throw new System.NotImplementedException();
	    }

	    public override void SetVolumeDetect(int param)
	    {
	        throw new System.NotImplementedException();
	    }

	    public override PhysicsVector GeometricCenter
	    {
	        get { throw new System.NotImplementedException(); }
	    }

	    public override PhysicsVector CenterOfMass
	    {
	        get { throw new System.NotImplementedException(); }
	    }

	    public override PhysicsVector Velocity
	    {
	        get { throw new System.NotImplementedException(); }
	        set { throw new System.NotImplementedException(); }
	    }

	    public override PhysicsVector Torque
	    {
	        get { throw new System.NotImplementedException(); }
	        set { throw new System.NotImplementedException(); }
	    }

	    public override float CollisionScore
	    {
	        get { throw new System.NotImplementedException(); }
	        set { throw new System.NotImplementedException(); }
	    }

	    public override PhysicsVector Acceleration
	    {
	        get { throw new System.NotImplementedException(); }
	    }

	    public override Quaternion Orientation
	    {
	        get { throw new System.NotImplementedException(); }
	        set { throw new System.NotImplementedException(); }
	    }

	    public override int PhysicsActorType
	    {
	        get { throw new System.NotImplementedException(); }
	        set { throw new System.NotImplementedException(); }
	    }

	    public override bool IsPhysical
	    {
	        get { throw new System.NotImplementedException(); }
	        set { throw new System.NotImplementedException(); }
	    }

	    public override bool Flying
	    {
	        get { throw new System.NotImplementedException(); }
	        set { throw new System.NotImplementedException(); }
	    }

	    public override bool SetAlwaysRun
	    {
	        get { throw new System.NotImplementedException(); }
	        set { throw new System.NotImplementedException(); }
	    }

	    public override bool ThrottleUpdates
	    {
	        get { throw new System.NotImplementedException(); }
	        set { throw new System.NotImplementedException(); }
	    }

	    public override bool IsColliding
	    {
	        get { throw new System.NotImplementedException(); }
	        set { throw new System.NotImplementedException(); }
	    }

	    public override bool CollidingGround
	    {
	        get { throw new System.NotImplementedException(); }
	        set { throw new System.NotImplementedException(); }
	    }

	    public override bool CollidingObj
	    {
	        get { throw new System.NotImplementedException(); }
	        set { throw new System.NotImplementedException(); }
	    }

	    public override bool FloatOnWater
	    {
	        set { throw new System.NotImplementedException(); }
	    }

	    public override PhysicsVector RotationalVelocity
	    {
	        get { throw new System.NotImplementedException(); }
	        set { throw new System.NotImplementedException(); }
	    }

	    public override bool Kinematic
	    {
	        get { throw new System.NotImplementedException(); }
	        set { throw new System.NotImplementedException(); }
	    }

	    public override float Buoyancy
	    {
	        get { throw new System.NotImplementedException(); }
	        set { throw new System.NotImplementedException(); }
	    }

	    public override PhysicsVector PIDTarget
	    {
	        set { throw new System.NotImplementedException(); }
	    }

	    public override bool PIDActive
	    {
	        set { throw new System.NotImplementedException(); }
	    }

	    public override float PIDTau
	    {
	        set { throw new System.NotImplementedException(); }
	    }

	    public override bool PIDHoverActive
	    {
	        set { throw new System.NotImplementedException(); }
	    }

	    public override float PIDHoverHeight
	    {
	        set { throw new System.NotImplementedException(); }
	    }

	    public override PIDHoverType PIDHoverType
	    {
	        set { throw new System.NotImplementedException(); }
	    }

	    public override float PIDHoverTau
	    {
	        set { throw new System.NotImplementedException(); }
	    }

	    public override void AddForce(PhysicsVector force, bool pushforce)
	    {
	        throw new System.NotImplementedException();
	    }

	    public override void AddAngularForce(PhysicsVector force, bool pushforce)
	    {
	        throw new System.NotImplementedException();
	    }

	    public override void SetMomentum(PhysicsVector momentum)
	    {
	        throw new System.NotImplementedException();
	    }

	    public override void SubscribeEvents(int ms)
	    {
	        throw new System.NotImplementedException();
	    }

	    public override void UnSubscribeEvents()
	    {
	        throw new System.NotImplementedException();
	    }

	    public override bool SubscribedEvents()
	    {
	        throw new System.NotImplementedException();
	    }

	    #endregion
	}
}
