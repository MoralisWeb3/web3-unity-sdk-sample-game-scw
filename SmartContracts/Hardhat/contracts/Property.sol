// SPDX-License-Identifier: MIT
pragma solidity ^0.8.9;


///////////////////////////////////////////////////////////
// IMPORTS
///////////////////////////////////////////////////////////
import "@openzeppelin/contracts/token/ERC721/extensions/ERC721URIStorage.sol";
import "@openzeppelin/contracts/utils/Counters.sol";
import "hardhat/console.sol";


///////////////////////////////////////////////////////////
// CLASS
//      *   Description:   
//          Each ERC721 instance here represents a globally 
//          unique Real-estate property for "Sim City Web3" 
//
//      *   Deployment Address  :   
///////////////////////////////////////////////////////////
contract Property is ERC721URIStorage 
{

    ///////////////////////////////////////////////////////////
    // FIELDS
    //      *   Values stored on contract
    ///////////////////////////////////////////////////////////


    // Auto generates tokenIds
    using Counters for Counters.Counter;
    Counters.Counter private _tokenIds;

    // The user who owns the ERC721 instance
    address owner;


    ///////////////////////////////////////////////////////////
    // MODIFIERS 
    ///////////////////////////////////////////////////////////
 

    ///////////////////////////////////////////////////////////
    // CONSTRUCTOR
    //      *   Runs when contract is executed
    ///////////////////////////////////////////////////////////
    constructor() ERC721("Property", "SCWP") 
    {
        // DISCLAIMER -- NOT A PRODUCTION READY CONTRACT
        // require(msg.sender == owner);
        owner = msg.sender;

        console.log(
            "Property.constructor() owner = %s",
            owner
        );
    } 



    ///////////////////////////////////////////////////////////
    // FUNCTIONS: GETTERS
    ///////////////////////////////////////////////////////////


    ///////////////////////////////////////////////////////////
    // FUNCTIONS: MINT
    //      *   Called from the game to mint a new property
    //      *   The tokenURI contains property metadata 
    //          (latitude, longitude)
    ///////////////////////////////////////////////////////////
    function mintPropertyNft(string memory tokenURI) public returns (uint256)
    {
        uint256 newItemId = _tokenIds.current();
        _mint(msg.sender, newItemId);
        _setTokenURI(newItemId, tokenURI);

        //TODO: Remove this return
        _tokenIds.increment();
        return newItemId;
    }


    ///////////////////////////////////////////////////////////
    // FUNCTIONS: BURN
    //      *   Called from the game to delete ("burn") an 
    //          existing property
    ///////////////////////////////////////////////////////////
    function burnPropertyNft(uint256 tokenId) public 
    {
        _burn(tokenId);
    }


    ///////////////////////////////////////////////////////////
    // FUNCTIONS: BURN
    //      *   Called from the game to delete ("burn") an      
    //          existing ARRAY OF properties
    ///////////////////////////////////////////////////////////
    function burnPropertyNfts(uint256[] calldata tokenIds) public
    {
        for (uint i=0; i<tokenIds.length; i++) {
            burnPropertyNft (tokenIds[i]);
        }
    }
}