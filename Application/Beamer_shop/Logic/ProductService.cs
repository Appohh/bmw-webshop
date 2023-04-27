﻿using Logic.Interfaces;
using Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class ProductService : IProductService
    {
        private readonly ICarRepository carRepository;
        private readonly IAccessoryRepository accessoryRepository;

        private IDictionary<int, Product> _products;

        public ProductService(ICarRepository carRepository, IAccessoryRepository accessoryRepository)
        {
            this.carRepository = carRepository
                ?? throw new ArgumentNullException(nameof(carRepository));
            this.accessoryRepository = accessoryRepository
                ?? throw new ArgumentNullException(nameof(accessoryRepository));

            _products = new Dictionary<int, Product>();
            retrieveData(); //timer?
        }

        private void retrieveData()
        {
            if (_products.Count > 0) { _products.Clear(); }

            foreach (Product car in carRepository.GetAllCars()) { _products.Add(car.Id, car); }
            foreach (Product accessory in accessoryRepository.GetAllAccessories()) { _products.Add(accessory.Id, accessory); }
        }

        public List<Product> GetAllProducts()
        {
            return _products.Values.ToList();
        }

        public Product? getProductById(int id)
        {
            if (_products.ContainsKey(id))
            {
                return _products[id];
            }
            else
            {
                return null;
            }
        }

        public List<string> GetProductImages(Product product)
        {
            if (product is Car)
                return carRepository.GetProductImages(product.Id);
            if (product is Accessory)
                return accessoryRepository.GetProductImages(product.Id);
            else { return new List<string>(); }
        }

        public List<Product> GetProductAccessories(Product product)
        {
            return accessoryRepository.GetProductAccessories(product.Id);
        }
    }
}
