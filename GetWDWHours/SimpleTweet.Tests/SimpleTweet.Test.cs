using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Utility;
using SimpleTweet;

namespace SimpleTweet.Tests
{
    public class SimpleTweetTest
    {

        [Fact]
        public void CreateNonce_ZeroSize_ReturnsEmptyString()
        {
            var nonceTest = new SimpleTweet();

            string nonce = nonceTest.CreateNonce(0);

            Assert.Empty(nonce);
        }

        [Fact]
        public void CreateNonce_NonZeroSize_ReturnsString()
        {
            var nonceTest = new SimpleTweet();

            string nonce = nonceTest.CreateNonce(32);

            Assert.NotEmpty(nonce);
        }

        [Fact]
        public void SendTwitterUpdate_Valid_Sent()
        {
            var sendTest = new SimpleTweet();

            sendTest.HTTPMethod = "POST";
            sendTest.BaseURL = "https://api.twitter.com/1.1/statuses/update.json";

            sendTest.ConsumerKey = "JfeQNOsC8oMC7HYf0UL6tmyC3";
            sendTest.Nonce = sendTest.CreateNonce(32);
            sendTest.SignatureMethod = "HMAC-SHA1";
            sendTest.TimeStamp = DateTime.Now.ToUnixTimestamp();
            sendTest.Token = "2997888023-rDEk8HGNtwHODUJ3CEDrNAEZ6wG1fHBuVAMO4zd";
            sendTest.Version = "1.0";
            sendTest.Request = "status=tweet me";
            sendTest.Include_Entities = "true";

            sendTest.ConsumerSecret = "H0OXLRHt0IvxsIkpokbqEgpBcP7BvjMUvsAjjMQbZerHULIuiF";
            sendTest.OAuth_token_secret = "tFNqW1lwlSUDfkHo8ET1EsGa7UiYpvHJc2daMAtkesW5w";
            bool sent = sendTest.PostUpdate("tweet me");

            Assert.True(sent);
        }

        [Fact]
        public void CalculateSignature()
        {
            var sigTest = new SimpleTweet();

            sigTest.HTTPMethod = "Post";
            sigTest.BaseURL = "https://api.twitter.com/1/statuses/update.json";

            sigTest.ConsumerKey = "xvz1evFS4wEEPTGEFPHBog";
            sigTest.Nonce = "kYjzVBB8Y0ZFabxSWbWovY3uYSQ2pTgmZeNu2VS4cg";
            sigTest.SignatureMethod = "HMAC-SHA1";
            sigTest.TimeStamp = "1318622958";
            sigTest.Token = "370773112-GmHxMAgYyLbNEtIKZeRNFsMKPR9EyMZeS9weJAEb";
            sigTest.Version = "1.0";
            sigTest.Request = "status=Hello Ladies + Gentlemen, a signed OAuth request!";
            sigTest.Include_Entities = "true";

            sigTest.ConsumerSecret = "kAcSOqF21Fu85e7zjz7ZN2U4ZRhfV3WpwPAoE3Z7kBw";
            sigTest.OAuth_token_secret = "LswwdoUaIvS8ltyTt5jkRh4J50vUPVVHtR2YPi5kE";

            string signKey = sigTest.CreateSigningKey();

            string signatureBase = sigTest.CreateSignatureBaseString();

            string signed = sigTest.CalculateSignature(signatureBase, signKey);

            Assert.Equal("tnnArxj06cWHq44gCs1OSKk/jLY=", signed);
        }

        [Fact]
        public void CreateSigningKey()
        {
            var sigTest = new SimpleTweet();

            sigTest.ConsumerSecret = "kAcSOqF21Fu85e7zjz7ZN2U4ZRhfV3WpwPAoE3Z7kBw";
            sigTest.OAuth_token_secret = "LswwdoUaIvS8ltyTt5jkRh4J50vUPVVHtR2YPi5kE";

            string signKey = sigTest.CreateSigningKey();

            Assert.Equal("kAcSOqF21Fu85e7zjz7ZN2U4ZRhfV3WpwPAoE3Z7kBw&LswwdoUaIvS8ltyTt5jkRh4J50vUPVVHtR2YPi5kE",
                signKey);
        }

        [Fact]
        public void CreateSignatureBaseString_ValidVaues_CreatesCorrectString()
        {

            var sigTest = new SimpleTweet();
            sigTest.HTTPMethod = "Post";
            sigTest.BaseURL = "https://api.twitter.com/1/statuses/update.json";

            sigTest.ConsumerKey = "xvz1evFS4wEEPTGEFPHBog";
            sigTest.Nonce = "kYjzVBB8Y0ZFabxSWbWovY3uYSQ2pTgmZeNu2VS4cg";
            sigTest.SignatureMethod = "HMAC-SHA1";
            sigTest.TimeStamp = "1318622958";
            sigTest.Token = "370773112-GmHxMAgYyLbNEtIKZeRNFsMKPR9EyMZeS9weJAEb";
            sigTest.Version = "1.0";
            sigTest.Request = "status=Hello Ladies + Gentlemen, a signed OAuth request!";
            sigTest.Include_Entities = "true";

            string signatureBase = sigTest.CreateSignatureBaseString();

            Assert.Equal("POST&https%3A%2F%2Fapi.twitter.com%2F1%2Fstatuses%2Fupdate.json&include_entities%3Dtrue%26oauth_consumer_key%3Dxvz1evFS4wEEPTGEFPHBog%26oauth_nonce%3DkYjzVBB8Y0ZFabxSWbWovY3uYSQ2pTgmZeNu2VS4cg%26oauth_signature_method%3DHMAC-SHA1%26oauth_timestamp%3D1318622958%26oauth_token%3D370773112-GmHxMAgYyLbNEtIKZeRNFsMKPR9EyMZeS9weJAEb%26oauth_version%3D1.0%26status%3DHello%2520Ladies%2520%252B%2520Gentlemen%252C%2520a%2520signed%2520OAuth%2520request%2521",
                signatureBase);

        }

        [Fact]
        public void CreateParamSignatureBase_HasValidValues_CreatesSignature()
        {
            var sigTest = new SimpleTweet();

            sigTest.ConsumerKey = "xvz1evFS4wEEPTGEFPHBog";
            sigTest.Nonce = "kYjzVBB8Y0ZFabxSWbWovY3uYSQ2pTgmZeNu2VS4cg";
            sigTest.SignatureMethod = "HMAC-SHA1";
            sigTest.TimeStamp = "1318622958";
            sigTest.Token = "370773112-GmHxMAgYyLbNEtIKZeRNFsMKPR9EyMZeS9weJAEb";
            sigTest.Version = "1.0";
            sigTest.Request = "status=Hello Ladies + Gentlemen, a signed OAuth request!";
            sigTest.Include_Entities = "true";

            string signature = sigTest.CreateParamSignatureBase();
            Assert.Equal("include_entities=true&oauth_consumer_key=xvz1evFS4wEEPTGEFPHBog&oauth_nonce=kYjzVBB8Y0ZFabxSWbWovY3uYSQ2pTgmZeNu2VS4cg&oauth_signature_method=HMAC-SHA1&oauth_timestamp=1318622958&oauth_token=370773112-GmHxMAgYyLbNEtIKZeRNFsMKPR9EyMZeS9weJAEb&oauth_version=1.0&status=Hello%20Ladies%20%2B%20Gentlemen%2C%20a%20signed%20OAuth%20request%21",
                signature);
            Assert.True(signature.Length > 0);
        }

        [Fact]
        public void GenerateParameterList_SingleParam_ParsedCorrectly()
        {
            var sigTest = new SimpleTweet();
            string request = "first=blah1";
            sigTest.Request = request;

            var test = sigTest.GenerateParameterList(request);

            Assert.Equal(1, test.Count);
        }

        [Fact]
        public void GenerateParameterList_TwoParam_ParsedCorrectly()
        {
            var sigTest = new SimpleTweet();
            string request = "first=blah1&second=blah2";
            sigTest.Request = request;

            var test = sigTest.GenerateParameterList(request);

            Assert.Equal(2, test.Count);
        }


        //[Fact]
        //public void Login()
        //{
        //    var simples = new SimpleTweet();
        //    bool result = simples.Login("simpletweetnet@gmail.com", "Testme123");

        //    Assert.True(result);
        //}
    }
}
