using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApricodeTestApi.Core.Repositories
{
    public interface IRepository<T>
    {
        /// <summary>
        /// Выполняет поиск объекта по идентификатору записи
        /// </summary>
        /// <param name="id">Идентификатор записи</param>
        /// <returns>Возвращает экземпляр, соответствующий идентификатору</returns>
        Task<T?> FindAsync(int id);

        /// <summary>
        /// Получает список всех объектов из хранилища данных
        /// </summary>
        /// <returns>Возвращает список записей</returns>
        Task<List<T>> GetAllAsync();

        /// <summary>
        /// Удаляет объект из хранилища данных по его идентификатору
        /// </summary>
        /// <param name="id">Идентификатор записи</param>
        Task RemoveAsync(int id);

        /// <summary>
        /// Добавляет объект в хранилище данных
        /// </summary>
        /// <param name="item">Объект для добавления</param>
        /// <returns>Возвращает экземпляр класса, измененный после добавления (назначен Id)</returns>
        Task<T> AddAsync(T item);

        /// <summary>
        /// Изменяет объект в хранилище данных. Объект для изменения определяется по идентификатору (Id).
        /// </summary>
        /// <param name="item">Объект для добавления</param>
        /// <returns>Возвращает экземпляр класса, измененный после добавления (назначен Id)</returns>
        Task<T> UpdateAsync(T item);
    }
}
