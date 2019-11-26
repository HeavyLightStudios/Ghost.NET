using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using HLStudios.GhostAPI.Enums;
using HLStudios.GhostAPI.Models;
using HLStudios.GhostAPI.Utilities;

namespace HLStudios.GhostAPI.APIs
{
    public class ContentApi
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;
        
        public ContentApi(string url, string apiKey)
        {
            _httpClient = new HttpClient();
            _apiKey = apiKey;

            _httpClient.BaseAddress = new Uri(url);
        }

        public async Task<Response<PostList>> BrowsePostsAsync(PostOptions options = null)
        {
            var requestUri = new StringBuilder();
            
            requestUri.Append($"/ghost/api/v3/content/posts/?key={_apiKey}");

            if (options != null)
            {
                requestUri.Append(options.Include != Include.None 
                    ? $"&include={options.Include.GetDescriptions()}" 
                    : string.Empty);
                requestUri.Append(options.Format != Format.None 
                    ? $"&formats={options.Format.GetDescriptions()}" 
                    : string.Empty);
                requestUri.Append(options.Fields != PostFields.None
                    ? $"&fields={options.Fields.GetDescriptions()}"
                    : string.Empty);
                
                requestUri.Append(options.Page != string.Empty 
                    ? $"&page={options.Page}" 
                    : string.Empty);
                requestUri.Append(options.Limit != string.Empty ? $"&limit={options.Limit}" : string.Empty);
                requestUri.Append(options.Filter != string.Empty ? $"&filter={options.Filter}" : string.Empty);
                requestUri.Append(options.Order != string.Empty ? $"&order={options.Order}" : string.Empty);
            }

            return await GetRequestAsync<PostList>(requestUri);
        }

        public async Task<Response<PostList>> ReadPostByIdAsync(string id, PostOptions options = null)
        {
            var requestUri = new StringBuilder();
            
            requestUri.Append($"/ghost/api/v3/content/posts/{id}/?key={_apiKey}");
            
            if (options != null)
            {
                // Adds optional request information to the call.
                requestUri.Append(options.Include != Include.None 
                    ? $"&include={options.Include.GetDescriptions()}" 
                    : string.Empty);
                requestUri.Append(options.Format != Format.None 
                    ? $"&formats={options.Format.GetDescriptions()}" 
                    : string.Empty);
                requestUri.Append(options.Fields != PostFields.None
                    ? $"&fields={options.Fields.GetDescriptions()}"
                    : string.Empty);
            }

            return await GetRequestAsync<PostList>(requestUri);
        }
        
        public async Task<Response<PostList>> ReadPostBySlugAsync(string slug, PostOptions options = null)
        {
            var requestUri = new StringBuilder();
            
            requestUri.Append($"/ghost/api/v3/content/posts/slug/{slug}/?key={_apiKey}");
            
            if (options != null)
            {
                // Adds optional request information to the call.
                requestUri.Append(options.Include != Include.None 
                    ? $"&include={options.Include.GetDescriptions()}" 
                    : string.Empty);
                requestUri.Append(options.Format != Format.None 
                    ? $"&formats={options.Format.GetDescriptions()}" 
                    : string.Empty);
                requestUri.Append(options.Fields != PostFields.None
                    ? $"&fields={options.Fields.GetDescriptions()}"
                    : string.Empty);
            }

            return await GetRequestAsync<PostList>(requestUri);
        }
        
        public async Task<Response<PageList>> BrowsePageAsync(PageOptions options = null)
        {
            var requestUri = new StringBuilder();
            
            requestUri.Append($"/ghost/api/v3/content/pages/?key={_apiKey}");

            if (options != null)
            {
                // Adds optional request information to the call.
                requestUri.Append(options.Include != Include.None 
                    ? $"&include={options.Include.GetDescriptions()}" 
                    : string.Empty);
                requestUri.Append(options.Format != Format.None 
                    ? $"&formats={options.Format.GetDescriptions()}" 
                    : string.Empty);
                requestUri.Append(options.Fields != PageFields.None
                    ? $"&fields={options.Fields.GetDescriptions()}"
                    : string.Empty);

                requestUri.Append(options.Page != string.Empty ? $"&page={options.Page}" : string.Empty);
                requestUri.Append(options.Limit != string.Empty ? $"&limit={options.Limit}" : string.Empty);
                requestUri.Append(options.Filter != string.Empty ? $"&filter={options.Filter}" : string.Empty);
                requestUri.Append(options.Order != string.Empty ? $"&order={options.Order}" : string.Empty);
            }

            return await GetRequestAsync<PageList>(requestUri);
        }
        
        public async Task<Response<PageList>> ReadPageByIdAsync(string id, PageOptions options = null)
        {
            var requestUri = new StringBuilder();
            
            requestUri.Append($"/ghost/api/v3/content/pages/{id}/?key={_apiKey}");
            
            if (options != null)
            {
                // Adds optional request information to the call.
                requestUri.Append(options.Include != Include.None 
                    ? $"&include={options.Include.GetDescriptions()}" 
                    : string.Empty);
                requestUri.Append(options.Format != Format.None 
                    ? $"&formats={options.Format.GetDescriptions()}" 
                    : string.Empty);
                requestUri.Append(options.Fields != PageFields.None
                    ? $"&fields={options.Fields.GetDescriptions()}"
                    : string.Empty);
            }

            return await GetRequestAsync<PageList>(requestUri);
        }
        
        public async Task<Response<PageList>> ReadPageBySlugAsync(string slug, PageOptions options = null)
        {
            var requestUri = new StringBuilder();
            
            requestUri.Append($"/ghost/api/v3/content/posts/slug/{slug}/?key={_apiKey}");
            
            if (options != null)
            {
                // Adds optional request information to the call.
                requestUri.Append(options.Include != Include.None 
                    ? $"&include={options.Include.GetDescriptions()}" 
                    : string.Empty);
                requestUri.Append(options.Format != Format.None 
                    ? $"&formats={options.Format.GetDescriptions()}" 
                    : string.Empty);
                requestUri.Append(options.Fields != PageFields.None
                    ? $"&fields={options.Fields.GetDescriptions()}"
                    : string.Empty);
            }
            
            return await GetRequestAsync<PageList>(requestUri);
        }
        
        public async Task<Response<TagList>> BrowseTagsAsync(TagOptions options = null)
        {
            var requestUri = new StringBuilder();
            
            requestUri.Append($"/ghost/api/v3/content/tags/?key={_apiKey}");
            
            if (options != null)
            {
                requestUri.Append(options.Include != Include.None 
                    ? $"&include={options.Include.GetDescriptions()}" 
                    : string.Empty);
                requestUri.Append(options.Fields != TagFields.None
                    ? $"&fields={options.Fields.GetDescriptions()}"
                    : string.Empty);
                
                requestUri.Append(options.Page != string.Empty ? $"&page={options.Page}" : string.Empty);
                requestUri.Append(options.Limit != string.Empty ? $"&limit={options.Limit}" : string.Empty);
                requestUri.Append(options.Filter != string.Empty ? $"&filter={options.Filter}" : string.Empty);
                requestUri.Append(options.Order != string.Empty ? $"&order={options.Order}" : string.Empty);
            }

            return await GetRequestAsync<TagList>(requestUri);
        }
        
        public async Task<Response<TagList>> ReadTagByIdAsync(string id, TagOptions options = null)
        {
            var requestUri = new StringBuilder();
            
            requestUri.Append($"/ghost/api/v3/content/tags/{id}/?key={_apiKey}");
            
            if (options != null)
            {
                requestUri.Append(options.Include != Include.None 
                    ? $"&include={options.Include.GetDescriptions()}" 
                    : string.Empty);
                requestUri.Append(options.Fields != TagFields.None
                    ? $"&fields={options.Fields.GetDescriptions()}"
                    : string.Empty);
            }

            return await GetRequestAsync<TagList>(requestUri);

        }
        
        public async Task<Response<TagList>> ReadTagBySlugAsync(string slug, TagOptions options = null)
        {
            var requestUri = new StringBuilder();
            
            requestUri.Append($"/ghost/api/v3/content/tags/slug/{slug}/?key={_apiKey}");
            
            if (options != null)
            {
                requestUri.Append(options.Include != Include.None 
                    ? $"&include={options.Include.GetDescriptions()}" 
                    : string.Empty);
                requestUri.Append(options.Fields != TagFields.None
                    ? $"&fields={options.Fields.GetDescriptions()}"
                    : string.Empty);
            }

            return await GetRequestAsync<TagList>(requestUri);
        }
        
        public async Task<Response<AuthorList>> BrowseAuthorsAsync(AuthorOptions options = null)
        {
            var requestUri = new StringBuilder();
            
            requestUri.Append($"/ghost/api/v3/content/authors/?key={_apiKey}");
            
            if (options != null)
            {
                requestUri.Append(options.Include != Include.None 
                    ? $"&include={options.Include.GetDescriptions()}" 
                    : string.Empty);
                requestUri.Append(options.Fields != AuthorFields.None
                    ? $"&fields={options.Fields.GetDescriptions()}"
                    : string.Empty);
                
                requestUri.Append(options.Page != string.Empty ? $"&page={options.Page}" : string.Empty);
                requestUri.Append(options.Limit != string.Empty ? $"&limit={options.Limit}" : string.Empty);
                requestUri.Append(options.Filter != string.Empty ? $"&filter={options.Filter}" : string.Empty);
                requestUri.Append(options.Order != string.Empty ? $"&order={options.Order}" : string.Empty);
            }

            return await GetRequestAsync<AuthorList>(requestUri);
        }
        
        public async Task<Response<AuthorList>> ReadAuthorByIdAsync(string id, AuthorOptions options = null)
        {
            var requestUri = new StringBuilder();
            
            requestUri.Append($"/ghost/api/v3/content/authors/{id}/?key={_apiKey}");
            
            if (options != null)
            {
                requestUri.Append(options.Include != Include.None 
                    ? $"&include={options.Include.GetDescriptions()}" 
                    : string.Empty);
                requestUri.Append(options.Fields != AuthorFields.None
                    ? $"&fields={options.Fields.GetDescriptions()}"
                    : string.Empty);
            }

            return await GetRequestAsync<AuthorList>(requestUri);
        }
        
        public async Task<Response<AuthorList>> ReadAuthorBySlugAsync(string slug, AuthorOptions options = null)
        {
            var requestUri = new StringBuilder();
            
            requestUri.Append($"/ghost/api/v3/content/authors/slug/{slug}/?key={_apiKey}");
            
            if (options != null)
            {
                requestUri.Append(options.Include != Include.None 
                    ? $"&include={options.Include.GetDescriptions()}" 
                    : string.Empty);
                requestUri.Append(options.Fields != AuthorFields.None
                    ? $"&fields={options.Fields.GetDescriptions()}"
                    : string.Empty);
            }

            return await GetRequestAsync<AuthorList>(requestUri);
        }

        public async Task<Response<SettingsRoot>> ReadSettingsAsync()
        {
            var requestUri = new StringBuilder();
            
            requestUri.Append($"/ghost/api/v3/content/settings/?key={_apiKey}");

            return await GetRequestAsync<SettingsRoot>(requestUri);
        }

        private async Task<Response<T>> GetRequestAsync<T>(StringBuilder requestUri)
        {
            try
            {
                using var response =
                    await _httpClient.GetAsync(requestUri.ToString());

                //TODO: send back error information from the API when response.EnsureStatusCode() fails. 
                if (response.StatusCode == HttpStatusCode.BadRequest ||
                    response.StatusCode == HttpStatusCode.Unauthorized ||
                    response.StatusCode == HttpStatusCode.NotFound ||
                    response.StatusCode == HttpStatusCode.InternalServerError)
                {

                    return new Response<T>
                    {
                        Content = default,
                        Error = JsonSerializer.Deserialize<ErrorList>(await response.Content.ReadAsStringAsync())
                    };
                }
                
                return new Response<T>
                {
                    Content = JsonSerializer.Deserialize<T>(await response.Content.ReadAsStringAsync()),
                    Error = null
                };
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}