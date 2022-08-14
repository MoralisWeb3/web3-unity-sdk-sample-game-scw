///////////////////////////////////////////////////////////
// REQUIRES
///////////////////////////////////////////////////////////
const {
    time,
    loadFixture,
} = require("@nomicfoundation/hardhat-network-helpers");
const { anyValue } = require("@nomicfoundation/hardhat-chai-matchers/withArgs");
const { expect } = require("chai");

///////////////////////////////////////////////////////////
// TEST
///////////////////////////////////////////////////////////
describe("TheGameLibrary", function ()
{
    async function deployTokenFixture() 
    {
        const [owner, addr1, addr2] = await ethers.getSigners();

        // TheGameLibrary
        const TheGameLibrary = await ethers.getContractFactory("TheGameLibrary");
        const theGameLibrary = await TheGameLibrary.deploy();
        await theGameLibrary.deployed();

        return { owner, addr1, addr2, theGameLibrary  };
    
    }


    ///////////////////////////////////////////////////////////
    // TEST
    ///////////////////////////////////////////////////////////
    it("Deploys with no exceptions", async function ()
    {
        // Arrange
        const { owner, addr1, addr2, theGameLibrary  } = await loadFixture(deployTokenFixture);

        // Act

        // Expect
        expect(true).to.equal(true);
    }),

    ///////////////////////////////////////////////////////////
    // TEST
    ///////////////////////////////////////////////////////////
    it("getSampleConstant returns 99", async function ()
    {
        // Arrange
        const { owner, addr1, addr2, theGameLibrary  } = await loadFixture(deployTokenFixture);

        // Act
        const result = await theGameLibrary.getSampleConstant();

        // Expect
        expect(result).to.equal(99);
    })
    
});
