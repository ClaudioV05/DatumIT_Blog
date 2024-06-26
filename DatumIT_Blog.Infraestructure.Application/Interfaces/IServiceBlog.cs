﻿using DatumIT_Blog.Infraestructure.Domain.Entities;

namespace DatumIT_Blog.Application.Interfaces;

/// <summary>
/// IServiceBlog
/// </summary>
/// <remarks>This class cannot be inherited.</remarks>
public interface IServiceBlog
{
    /// <summary>
    /// Create.
    /// </summary>
    /// <param name="obj"></param>
    /// <paramref name=""/>
    /// <remarks></remarks>
    /// <exception cref=""></exception>
    /// <seealso href=""></seealso>
    /// <returns></returns>
    Task Create(Blog obj);

    /// <summary>
    /// Read.
    /// </summary>
    /// <param name=""></param>
    /// <paramref name=""/>
    /// <remarks></remarks>
    /// <exception cref=""></exception>
    /// <seealso href=""></seealso>
    /// <returns></returns>
    Task<IEnumerable<Blog>> Read();

    /// <summary>
    /// Update.
    /// </summary>
    /// <param name="obj"></param>
    /// <paramref name=""/>
    /// <remarks></remarks>
    /// <exception cref=""></exception>
    /// <seealso href=""></seealso>
    /// <returns></returns>
    Task Update(Blog obj);

    /// <summary>
    /// Delete.
    /// </summary>
    /// <param name="id"></param>
    /// <paramref name=""/>
    /// <remarks></remarks>
    /// <exception cref=""></exception>
    /// <seealso href=""></seealso>
    /// <returns></returns>
    Task Delete(int id);
}