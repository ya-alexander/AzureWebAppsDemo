using Microsoft.Azure.KeyVault;
using Microsoft.Azure.Services.AppAuthentication;
using Microsoft.Rest.TransientFaultHandling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BesiGourmet.KeyVault
{
	public class KVClient
	{
		private readonly string _keyVaultUri;

		public KVClient(string keyVaultUri)
		{
			_keyVaultUri = keyVaultUri;
		}

		public async Task<string> GetValueAsync(string key)
		{
			var azureServiceTokenProvider = new AzureServiceTokenProvider();
			var kv = new KeyVaultClient(new KeyVaultClient.AuthenticationCallback(azureServiceTokenProvider.KeyVaultTokenCallback));
			kv.SetRetryPolicy(new RetryPolicy(new TransientErrorIgnoreStrategy(), 5));
			var secretUri = $"{_keyVaultUri}secrets/{key}";
			var secret = await kv.GetSecretAsync(secretUri);
			return secret.Value;
		}

	}
}
