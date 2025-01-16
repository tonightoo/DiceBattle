using Application.IPresenters;
using Application.Repositories;
using Application.Scenes;
using Domain.DataObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.UnitSelect
{
    public class UnitSelectUseCase : IUnitSelectUseCase
    {

        private readonly IUnitRepository _unitRepository;

        private readonly IUnitSelectPresenter _presenter;

        public UnitSelection _unitSelection;

        public UnitSelectUseCase(IUnitRepository repository, IUnitSelectPresenter presenter, UnitSelection unitSelection) 
        {
            _unitRepository = repository;
            _presenter = presenter;
            _unitSelection = unitSelection;
            PrivateInitialize();
        }

        public IUnitSelectUseCase Initialize()
        {
            return new UnitSelectUseCase(_unitRepository, _presenter, _unitSelection.Initialize());
        }

        private void PrivateInitialize()
        {
            int yNum = _unitSelection.YNum;
            int xNum = _unitSelection.XNum;

            Dictionary<int, Unit> lists =_unitRepository.GetAllUnits();

            for (int i = 0; i < yNum; i++)
            {
                for (int j = 0; j < xNum; j++)
                {
                    int index = i * xNum + j;
                    if (lists.Keys.Count <= index)
                    {
                        break;
                    }
                    int key = lists.Keys.ToList()[index];
                    _unitSelection.Units[i, j] = lists[key];
                }
            }
        }

        public UnitSelection Decide()
        {
            if (_unitSelection.LeftUnitSelection == null)
            {
                _unitSelection.LeftUnitSelection = _unitSelection.CurrentSelection;
            } 
            else if (_unitSelection.RightUnitSelection == null)
            {
                _unitSelection.RightUnitSelection = _unitSelection.CurrentSelection;
            } 
            else if (_unitSelection.LeftUnitSelection != null && _unitSelection.RightUnitSelection != null)
            {
                _unitSelection.IsSelected = true;
            }

            return _unitSelection;
        }

        public UnitSelection Cancel()
        {
            Point right = _unitSelection.RightUnitSelection;
            Point left = _unitSelection.LeftUnitSelection;

            if (left != null && right != null) 
            {
                _unitSelection.RightUnitSelection = null;
                _unitSelection.IsSelected = false;
            }
            else if (left == null && right == null)
            {
                _unitSelection.IsExit = true;
            }
            else if (left != null)
            {
                _unitSelection.LeftUnitSelection = null;
            }

            return _unitSelection;
        }

        public void ScreenUpdate()
        {
            _presenter.UpdateScreen(_unitSelection);
        }

        public void Right()
        {
            Point current = _unitSelection.CurrentSelection;
            int nextX = current.X + 1;
            int nextY = current.Y;

            if (nextX < _unitSelection.XNum)
            {
                if (_unitSelection.Units[nextY, nextX] == null)
                {
                    return;
                }
                _unitSelection.CurrentSelection = new Point(nextX, nextY);
            }
        }

        public void Left()
        {
            Point current = _unitSelection.CurrentSelection;
            int nextX = current.X - 1;
            int nextY = current.Y;
            
            if (nextX >= 0)
            {
                if (_unitSelection.Units[nextY, nextX] == null)
                {
                    return;
                }
                _unitSelection.CurrentSelection = new Point(nextX, nextY);
            }
        }

        public void Up()
        {
            Point current = _unitSelection.CurrentSelection;
            int nextX = current.X;
            int nextY = current.Y - 1;
            
            if (nextY >= 0)
            {
                if (_unitSelection.Units[nextY, nextX] == null)
                {
                    return;
                }
                _unitSelection.CurrentSelection = new Point(nextX, nextY);
            }
        }

        public void Down()
        {
            Point current = _unitSelection.CurrentSelection;
            int nextX = current.X;
            int nextY = current.Y + 1;
            
            if (nextY < _unitSelection.YNum)
            {
                if (_unitSelection.Units[nextY, nextX] == null)
                {
                    return;
                }
                _unitSelection.CurrentSelection = new Point(nextX, nextY);
            }
        }

    }
}
