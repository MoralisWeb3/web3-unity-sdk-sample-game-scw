// SPDX-License-Identifier: MIT
pragma solidity ^0.8.7;

// Imports
import "@openzeppelin/contracts/token/ERC721/extensions/ERC721URIStorage.sol";
import "@openzeppelin/contracts/utils/Counters.sol";

// Related Documentation
// Standard Nft - https://docs.openzeppelin.com/contracts/4.x/api/token/erc721#ERC721URIStorage
// Burnable Nft - https://github.com/OpenZeppelin/openzeppelin-contracts/blob/master/contracts/token/ERC721/extensions/ERC721Burnable.sol

// Class Purpose
//      Each ERC721 instance here represents a globally unique 
//      Real-estate property for the "Sim City Web3" game
// Class Deployment Address
//      TODO: UPDATE THIS AFTER EACH DEPLOYMENT: 0x9079e5219d17B04a0d17Df57eD7b1E6696406393 
contract Property is ERC721URIStorage 
{
    // Auto generates tokenIds
    using Counters for Counters.Counter;
    Counters.Counter private _tokenIds;

    // The user who owns the ERC721 instance
    address owner;

    // Cosmetic token naming of "SCWP" 
    // which means "Sim City Web3 Property"
    constructor() ERC721("Property", "SCWP") 
    {
        owner = msg.sender;
    } 

    // Called from the game to mint a new property
    // The tokenURI contains property metadata (latitude, longitude)
    function mintPropertyNft(string memory tokenURI) public returns (uint256)
    {
        // DISCLAIMER -- NOT A PRODUCTION READY CONTRACT
        // require(msg.sender == owner);

        uint256 newItemId = _tokenIds.current();
        _mint(msg.sender, newItemId);
        _setTokenURI(newItemId, tokenURI);

        _tokenIds.increment();
        return newItemId;
    }

    // Called from the game to delete ("burn") an existing property
    function burnPropertyNft(uint256 tokenId) public returns (string memory) 
    {
        // DISCLAIMER -- NOT A PRODUCTION READY CONTRACT
        // require(msg.sender == owner);

        _burn(tokenId);
        return "Success!";
    }

    // Called from the game to delete ("burn") an existing ARRAY OF properties
    function burnPropertyNfts(uint256[] calldata tokenIds) public returns (string memory) 
    {
        // DISCLAIMER -- NOT A PRODUCTION READY CONTRACT
        // require(msg.sender == owner);

        for (uint i=0; i<tokenIds.length; i++) {
            burnPropertyNft (tokenIds[i]);
        }
        
        return "Success!";
    }
}