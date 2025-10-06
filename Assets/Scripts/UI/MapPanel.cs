using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MapPanel : MonoBehaviour
{
    public event Action<RoomUI> OnRoomChoosed;

    public RoomUI LastRoom {  get; private set; }

    public List<RoomUI> _roomsList;

    public void Init()
    {
        foreach(RoomUI room in _roomsList)
        {
            room.OnRoomChoosed += RoomChoosed;
        }
    }

    public void RoomChoosed(RoomUI roomUI)
    {
        LastRoom = roomUI;
        roomUI.SetAnimStatus(false);
        OnRoomChoosed?.Invoke(roomUI);
    }

    public void ShowAvailableRooms()
    {
        List<RoomUI> _notPassedRooms = _roomsList.Where(x => !x.IsPassed).ToList();

        foreach(var room in _notPassedRooms)
        {
            room.SetOpenStatus(false);
        }

        if(LastRoom != null)
        {
            foreach(var room in LastRoom.RoomsForOpen)
            {
                room.SetOpenStatus(true);
            }
            LastRoom.SetPassed();
        }
        else
        {
            List<RoomUI> roomsFirstStage = _roomsList.Where(x => x.StageType == StageType.One).ToList();
            foreach (var room in roomsFirstStage)
            {
                room.SetOpenStatus(true);
            }
        }

    }
}
