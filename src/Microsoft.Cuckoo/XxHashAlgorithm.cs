﻿// -----------------------------------------------------------------------
// <copyright file="XxHashAlgorithm.cs" company="Microsoft">
//     Copyright (c) Microsoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Microsoft.Cuckoo
{
  using Standart.Hash.xxHash;

  /// <summary>
  /// An IHashAlgorithm using XxHash.
  /// </summary>
  public class XxHashAlgorithm : IHashAlgorithm
  {
    internal static readonly IHashAlgorithm Instance = new XxHashAlgorithm();

    private readonly ulong seed;

    /// <summary>
    /// Creates a new xxhash algorithm instance.
    /// </summary>
    /// <param name="seed">Seed value for the hash</param>
    public XxHashAlgorithm(ulong seed = 0)
    {
      this.seed = seed;
    }

    /// <summary>
    /// Returns a hash of the value.
    /// </summary>
    /// <param name="target">Target array to hash to</param>
    /// <param name="value">Value to hash</param>
    /// <param name="hashLength">Desired length of the fingerprint.</param>
    public void Hash(byte[] target, byte[] value, int hashLength)
    {
      var hash = xxHash64.ComputeHash(value, value.Length, this.seed);
      for (var i = 0; i < hashLength; i++)
      {
        target[i] = (byte)(hash & 0xFF);
        hash >>= 8;
      }
    }
  }
}
