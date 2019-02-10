using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreezingFruitFoot.Models
{
    public class RepositoryResponse<T>
    {
        private bool isSuccess;
        private string message;
        private T content;

        public bool IsSuccess { get => isSuccess; set => isSuccess = value; }
        public string Message { get => message; set => message = value; }
        public T Content { get => content; set => content = value; }
    }
}
