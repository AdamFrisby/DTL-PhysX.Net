using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Nini.Config;
using OpenMetaverse;
using OpenSim.Framework;
using OpenSim.Region.Physics.Manager;
using StillDesign.PhysX;
using Vector3=SlimDX.Vector3;

namespace DeepThink.PhysX
{
	class DTLPhysXScene : PhysicsScene
    {
        #region Physics Setup

	    private Core physicsCore;
	    private Scene physicsScene;

	    private Mutex physicsLock;

        Actor CreateActorFromHeightmap(float[] heightmap)
        {
            HeightFieldSample[] samples = new HeightFieldSample[heightmap.Length];

            float min = float.MaxValue, max = float.MinValue;

            for(int i=0;i<heightmap.Length;i++)
            {
                if(heightmap[i] > max)
                    max = heightmap[i];
                if(heightmap[i] < min)
                    min = heightmap[i];
            }

            
            for(int i=0;i<heightmap.Length;i++)
            {
                short normValue = (short) ((float) ((heightmap[i] - min)/(max - min))*(float) short.MaxValue);

                samples[i] = new HeightFieldSample();
                samples[i].Height = normValue;
                samples[i].MaterialIndex0 = 0;
                samples[i].MaterialIndex1 = 1;
                samples[i].TessellationFlag = 0; // Might be important?
            }

            HeightFieldDescription heightFieldDescription = new HeightFieldDescription();

            // Might cause fun with MegaRegions
            heightFieldDescription.NumberOfRows = (int) Constants.RegionSize;
            heightFieldDescription.NumberOfColumns = (int) Constants.RegionSize;

            HeightField heightField = physicsCore.CreateHeightField(heightFieldDescription);

            HeightFieldShapeDescription heightFieldShapeDescription = new HeightFieldShapeDescription()
                                                                          {
                                                                              HeightField = heightField,
                                                                              HoleMaterial = 2,
                                                                              HeightScale = (max - min),
                                                                              RowScale = 1.0f,
                                                                              ColumnScale = 1.0f
                                                                          };

            heightFieldShapeDescription.LocalPosition = new Vector3(0, 0, min); // May need to move to ActorDescription.GlobalPos?

            ActorDescription actorDescription = new ActorDescription()
                                                    {
                                                        Shapes = {heightFieldShapeDescription}
                                                    };

            Actor actor = physicsScene.CreateActor(actorDescription);

            return actor;
        }

        #endregion

        public DTLPhysXScene()
        {
            physicsCore = new Core();

            SceneDescription sceneDescription = new SceneDescription()
                                                    {
                                                        Gravity = new Vector3(0, 0, -9.81f),
                                                        GroundPlaneEnabled = true // Disable once terrain is confirmed working.
                                                    };

            physicsScene = physicsCore.CreateScene(sceneDescription);

            SimulationType simtype = physicsScene.SimulationType;
            if(simtype == SimulationType.Hardware)
            {
                
            }
            // Win!
        }

        #region Overrides of PhysicsScene

        public override void Initialise(IMesher meshmerizer, IConfigSource config)
	    {
	        throw new System.NotImplementedException();
	    }

	    public override PhysicsActor AddAvatar(string avName, PhysicsVector position, PhysicsVector size, bool isFlying)
	    {
	        throw new System.NotImplementedException();
	    }

	    public override void RemoveAvatar(PhysicsActor actor)
	    {
	        throw new System.NotImplementedException();
	    }

	    public override void RemovePrim(PhysicsActor prim)
	    {
	        throw new System.NotImplementedException();
	    }

	    public override PhysicsActor AddPrimShape(string primName, PrimitiveBaseShape pbs, PhysicsVector position, PhysicsVector size, Quaternion rotation)
	    {
	        throw new System.NotImplementedException();
	    }

	    public override PhysicsActor AddPrimShape(string primName, PrimitiveBaseShape pbs, PhysicsVector position, PhysicsVector size, Quaternion rotation, bool isPhysical)
	    {
	        throw new System.NotImplementedException();
	    }

	    public override void AddPhysicsActorTaint(PhysicsActor prim)
	    {
	        throw new System.NotImplementedException();
	    }

	    public override float Simulate(float timeStep)
	    {
            lock (physicsScene)
            {
                physicsScene.Simulate(timeStep);
            }
	        return timeStep;
	    }

	    public override void GetResults()
	    {
	        throw new System.NotImplementedException();
	    }

	    public override void SetTerrain(float[] heightMap)
	    {
	        throw new System.NotImplementedException();
	    }

	    public override void SetWaterLevel(float baseheight)
	    {
	        throw new System.NotImplementedException();
	    }

	    public override void DeleteTerrain()
	    {
	        throw new System.NotImplementedException();
	    }

	    public override void Dispose()
	    {
	        throw new System.NotImplementedException();
	    }

	    public override Dictionary<uint, float> GetTopColliders()
	    {
	        throw new System.NotImplementedException();
	    }

	    public override bool IsThreaded
	    {
	        get { throw new System.NotImplementedException(); }
	    }

	    #endregion
	}
}
