// SPDX-License-Identifier: MIT
pragma solidity ^0.8.9;


///////////////////////////////////////////////////////////
// IMPORTS
///////////////////////////////////////////////////////////
import "@openzeppelin/contracts/utils/Strings.sol";

///////////////////////////////////////////////////////////
// LIBRARY
//      *   Description:   
//          This is a demo of a working  library of
//          reusable functions and constants. It is not 
//          strictly required for this project.
//
//      *   Deployment Address  :   
///////////////////////////////////////////////////////////
library TheGameLibrary 
{
    ///////////////////////////////////////////////////////////
    // CONTANTS
    ///////////////////////////////////////////////////////////

    // Optional: Add any common, reusable methods here ...
    uint constant SampleConstant = 99;             

    ///////////////////////////////////////////////////////////
    // FUNCTIONS: 
    ///////////////////////////////////////////////////////////

    // Optional: Add any common, reusable methods here ...
    function getSampleConstant() public pure returns (uint)
    {
        return SampleConstant;
    }
}